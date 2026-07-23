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
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly string _cs;

        public ProjectTaskRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public int AddProjectTask(ProjectTaskDto projectTask, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectTask_Add", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProjectID", projectTask.ProjectID);
            command.Parameters.AddWithValue("@TaskName", projectTask.TaskName);
            command.Parameters.AddWithValue("@Description", (object?)projectTask.Description ?? DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", (object?)projectTask.StartDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@EndDate", (object?)projectTask.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@StatusID", projectTask.StatusID);
            command.Parameters.AddWithValue("@Weight", projectTask.Weight);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();

            var result = command.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public bool UpdateProjectTask(ProjectTaskDto projectTask, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectTask_Update", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@TaskID", projectTask.TaskID);
            command.Parameters.AddWithValue("@ProjectID", projectTask.ProjectID);
            command.Parameters.AddWithValue("@TaskName", projectTask.TaskName);
            command.Parameters.AddWithValue("@Description", (object?)projectTask.Description ?? DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", (object?)projectTask.StartDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@EndDate", (object?)projectTask.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@StatusID", projectTask.StatusID);
            command.Parameters.AddWithValue("@Weight", projectTask.Weight);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public ProjectTaskDto? GetProjectTaskByID(int taskID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectTask_GetByID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TaskID", taskID);

            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new ProjectTaskDto(
                    reader.GetInt32(reader.GetOrdinal("TaskID")),
                    reader.GetInt32(reader.GetOrdinal("ProjectID")),
                    reader.GetString(reader.GetOrdinal("TaskName")),
                    reader["Description"] as string,
                    reader["StartDate"] == DBNull.Value ? null : DateOnly.FromDateTime((DateTime)reader["StartDate"]),
                    reader["EndDate"] == DBNull.Value ? null : DateOnly.FromDateTime((DateTime)reader["EndDate"]),
                    reader.GetDecimal(reader.GetOrdinal("ProgressPercent")),
                    reader.GetInt32(reader.GetOrdinal("StatusID")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    reader.GetString(reader.GetOrdinal("CreatedBy")),
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string,
                    reader.GetDecimal(reader.GetOrdinal("Weight")),
                    reader.GetBoolean(reader.GetOrdinal("IsActive"))
                );
            }

            return null;
        }

        public List<ProjectTaskDto> GetProjectTasksByProjectID(int projectID)
        {
            var list = new List<ProjectTaskDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectTask_GetByProjectID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectID", projectID);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ProjectTaskDto(
                    reader.GetInt32(reader.GetOrdinal("TaskID")),
                    reader.GetInt32(reader.GetOrdinal("ProjectID")),
                    reader.GetString(reader.GetOrdinal("TaskName")),
                    reader["Description"] as string,
                    reader["StartDate"] == DBNull.Value ? null : DateOnly.FromDateTime((DateTime)reader["StartDate"]),
                    reader["EndDate"] == DBNull.Value ? null : DateOnly.FromDateTime((DateTime)reader["EndDate"]),
                    reader.GetDecimal(reader.GetOrdinal("ProgressPercent")),
                    reader.GetInt32(reader.GetOrdinal("StatusID")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    reader.GetString(reader.GetOrdinal("CreatedBy")),
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string,
                    reader.GetDecimal(reader.GetOrdinal("Weight")),
                    reader.GetBoolean(reader.GetOrdinal("IsActive"))
                ));
            }

            return list;
        }

        public bool DeactivateProjectTask(int taskID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectTask_Deactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TaskID", taskID);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public bool ReactivateProjectTask(int taskID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectTask_Reactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TaskID", taskID);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

    }
}

/*
================================================================================
ProjectTaskRepository
================================================================================

Purpose:
--------
Responsible for managing project tasks and their related data.

Implemented Operations:
-----------------------
- AddProjectTask
- UpdateProjectTask
- GetProjectTaskByID
- GetProjectTasksByProjectID
- DeactivateProjectTask
- ReactivateProjectTask

Design Principles:
------------------
- Repository Pattern
- Single Responsibility Principle (SRP)
- Clean Architecture
- DTO-Based Communication
- Dependency Injection

Implementation Approach:
------------------------
- All operations are executed through Stored Procedures.
- Repository contains no business logic.
- Repository is responsible only for data access.
- Add operation returns the newly created TaskID.
- Update/Deactivate/Reactivate return bool.
- GetProjectTaskByID returns ProjectTaskDto?.
- GetProjectTasksByProjectID returns List<ProjectTaskDto>.

Why This Repository Exists:
---------------------------
To provide a centralized and maintainable way to manage project tasks,
their status, progress, duration, and weight while keeping database
operations separated from business rules and application logic.

================================================================================
*/