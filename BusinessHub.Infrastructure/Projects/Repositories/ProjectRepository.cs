using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Infrastructure.Projects.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly string _cs;

        public ProjectRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }


        public int AddProject(ProjectDto project, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_Project_Add", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@BranchID", project.BranchID);
            command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
            command.Parameters.AddWithValue("@ClientID", (object?)project.ClientID ?? DBNull.Value);
            command.Parameters.AddWithValue("@TotalBudget", (object?)project.TotalBudget ?? DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", (object?)project.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@StatusID", project.StatusID);
            command.Parameters.AddWithValue("@Notes", (object?)project.Notes ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();

            var result = command.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public bool UpdateProject(ProjectDto project, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_Project_Update", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProjectID", project.ProjectID);
            command.Parameters.AddWithValue("@BranchID", project.BranchID);
            command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
            command.Parameters.AddWithValue("@ClientID", (object?)project.ClientID ?? DBNull.Value);
            command.Parameters.AddWithValue("@TotalBudget", (object?)project.TotalBudget ?? DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", (object?)project.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@StatusID", project.StatusID);
            command.Parameters.AddWithValue("@Notes", (object?)project.Notes ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public List<ProjectDto> GetAllProjects()
        {
            var list = new List<ProjectDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_Project_GetAll", connection);

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ProjectDto(
                    reader.GetInt32(reader.GetOrdinal("ProjectID")),
                    reader.GetInt32(reader.GetOrdinal("BranchID")),
                    reader.GetString(reader.GetOrdinal("ProjectName")),
                    reader["ClientID"] as int?,
                    reader["TotalBudget"] as decimal?,
                    DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("StartDate"))),
                    reader["EndDate"] == DBNull.Value
                        ? null
                        : DateOnly.FromDateTime((DateTime)reader["EndDate"]),
                    reader["IsActive"] as bool?,
                    reader.GetInt32(reader.GetOrdinal("StatusID")),
                    reader["Notes"] as string,
                    reader["CreatedAt"] as DateTime?,
                    reader["CreatedBy"] as string,
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                ));
            }

            return list;
        }

        public ProjectDto? GetProjectByID(int projectID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_Project_GetByID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectID", projectID);

            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new ProjectDto(
                    reader.GetInt32(reader.GetOrdinal("ProjectID")),
                    reader.GetInt32(reader.GetOrdinal("BranchID")),
                    reader.GetString(reader.GetOrdinal("ProjectName")),
                    reader["ClientID"] as int?,
                    reader["TotalBudget"] as decimal?,
                    DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("StartDate"))),
                    reader["EndDate"] == DBNull.Value
                        ? null
                        : DateOnly.FromDateTime((DateTime)reader["EndDate"]),
                    reader["IsActive"] as bool?,
                    reader.GetInt32(reader.GetOrdinal("StatusID")),
                    reader["Notes"] as string,
                    reader["CreatedAt"] as DateTime?,
                    reader["CreatedBy"] as string,
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                );
            }

            return null;
        }

        public bool DeactivateProject(int projectID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_Project_Deactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectID", projectID);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public bool ReactivateProject(int projectID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_Project_Reactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectID", projectID);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

    }
}

/*
================================================================================
ProjectRepository
================================================================================

Purpose:
--------
Responsible for all database operations related to Projects.

Implemented Operations:
-----------------------
- AddProject
- UpdateProject
- GetProjectByID
- GetAllProjects
- DeactivateProject
- ReactivateProject

Design Principles:
------------------
- Repository Pattern
- Single Responsibility Principle (SRP)
- Clean Architecture
- DTO-Based Communication
- Dependency Injection

Implementation Approach:
------------------------
- All database access is performed through Stored Procedures.
- No business rules exist inside the repository.
- Repository only sends and retrieves data.
- Add operations return the newly created ProjectID.
- Update/Deactivate/Reactivate return bool.
- GetByID returns ProjectDto?.
- GetAll returns List<ProjectDto>.

Why This Repository Exists:
---------------------------
To isolate database access from the business layer and provide a
centralized, maintainable, and consistent way to manage Project data
throughout the BusinessHub system.

================================================================================
*/