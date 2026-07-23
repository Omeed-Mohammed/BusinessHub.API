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
    public class ProjectEmployeeRepository : IProjectEmployeeRepository
    {
        private readonly string _cs;

        public ProjectEmployeeRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public int AddProjectEmployee(ProjectEmployeeDto projectEmployee, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectEmployee_Add", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProjectID", projectEmployee.ProjectID);
            command.Parameters.AddWithValue("@EmployeeID", projectEmployee.EmployeeID);
            command.Parameters.AddWithValue("@Role", (object?)projectEmployee.Role ?? DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", projectEmployee.StartDate);
            command.Parameters.AddWithValue("@EndDate", (object?)projectEmployee.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();

            var result = command.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public bool UpdateProjectEmployee(ProjectEmployeeDto projectEmployee, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectEmployee_Update", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProjectEmployeeID", projectEmployee.ProjectEmployeeID);
            command.Parameters.AddWithValue("@ProjectID", projectEmployee.ProjectID);
            command.Parameters.AddWithValue("@EmployeeID", projectEmployee.EmployeeID);
            command.Parameters.AddWithValue("@Role", (object?)projectEmployee.Role ?? DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", projectEmployee.StartDate);
            command.Parameters.AddWithValue("@EndDate", (object?)projectEmployee.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public List<ProjectEmployeeDto> GetProjectEmployeesByProjectID(int projectID)
        {
            var list = new List<ProjectEmployeeDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectEmployee_GetByProjectID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectID", projectID);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ProjectEmployeeDto(
                    reader.GetInt32(reader.GetOrdinal("ProjectEmployeeID")),
                    reader.GetInt32(reader.GetOrdinal("ProjectID")),
                    reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                    reader["Role"] as string,
                    DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("StartDate"))),
                    reader["EndDate"] == DBNull.Value
                        ? null
                        : DateOnly.FromDateTime((DateTime)reader["EndDate"]),
                    reader["IsActive"] as bool?,
                    reader["CreatedAt"] as DateTime?,
                    reader["CreatedBy"] as string,
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                ));
            }

            return list;
        }

        public ProjectEmployeeDto? GetProjectEmployeeByID(int projectEmployeeID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectEmployee_GetByID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectEmployeeID", projectEmployeeID);

            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new ProjectEmployeeDto(
                    reader.GetInt32(reader.GetOrdinal("ProjectEmployeeID")),
                    reader.GetInt32(reader.GetOrdinal("ProjectID")),
                    reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                    reader["Role"] as string,
                    DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("StartDate"))),
                    reader["EndDate"] == DBNull.Value
                        ? null
                        : DateOnly.FromDateTime((DateTime)reader["EndDate"]),
                    reader["IsActive"] as bool?,
                    reader["CreatedAt"] as DateTime?,
                    reader["CreatedBy"] as string,
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                );
            }

            return null;
        }

        public List<ProjectEmployeeDto> GetProjectEmployeeByEmployeeID(int employeeID)
        {
            var list = new List<ProjectEmployeeDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectEmployee_GetByEmployeeID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", employeeID);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ProjectEmployeeDto(
                    reader.GetInt32(reader.GetOrdinal("ProjectEmployeeID")),
                    reader.GetInt32(reader.GetOrdinal("ProjectID")),
                    reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                    reader["Role"] as string,
                    DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("StartDate"))),
                    reader["EndDate"] == DBNull.Value
                        ? null
                        : DateOnly.FromDateTime((DateTime)reader["EndDate"]),
                    reader["IsActive"] as bool?,
                    reader["CreatedAt"] as DateTime?,
                    reader["CreatedBy"] as string,
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                ));
            }

            return list;
        }

        public bool DeactivateProjectEmployee(int projectEmployeeID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectEmployee_Deactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectEmployeeID", projectEmployeeID);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public bool ReactivateProjectEmployee(int projectEmployeeID)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectEmployee_Reactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectEmployeeID", projectEmployeeID);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }
    }
}

/*
================================================================================
ProjectEmployeeRepository
================================================================================

Purpose:
--------
Responsible for managing employee assignments within projects.

Implemented Operations:
-----------------------
- AddProjectEmployee
- UpdateProjectEmployee
- GetProjectEmployeeByID
- GetProjectEmployeeByEmployeeID
- GetProjectEmployeesByProjectID
- DeactivateProjectEmployee
- ReactivateProjectEmployee

Design Principles:
------------------
- Repository Pattern
- Single Responsibility Principle (SRP)
- Clean Architecture
- DTO-Based Communication
- Dependency Injection

Implementation Approach:
------------------------
- All database operations are executed through Stored Procedures.
- Repository contains no business rules.
- Repository is responsible only for data access.
- Add operation returns the newly created ProjectEmployeeID.
- Update/Deactivate/Reactivate return bool.
- GetProjectEmployeeByID returns ProjectEmployeeDto?.
- Query operations return List<ProjectEmployeeDto>.

Why This Repository Exists:
---------------------------
To provide a centralized and maintainable way to manage employee
assignments, roles, and participation periods inside projects while
keeping data access separated from business logic.

================================================================================
*/