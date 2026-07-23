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
    public class ProjectStatusRepository : IProjectStatusRepository
    {
        private readonly string _cs;

        public ProjectStatusRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public List<ProjectStatusDto> GetAllProjectStatus()
        {
            var list = new List<ProjectStatusDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("proj.SP_ProjectStatus_GetAll", connection);

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ProjectStatusDto(
                    reader.GetInt32(reader.GetOrdinal("StatusID")),
                    reader.GetString(reader.GetOrdinal("Name"))
                ));
            }

            return list;
        }
    }
}

/*
================================================================================
ProjectStatusRepository
================================================================================

Purpose:
--------
Responsible for retrieving project status records used by Projects and
Project Tasks.

Implemented Operations:
-----------------------
- GetAllProjectStatus

Design Principles:
------------------
- Repository Pattern
- Single Responsibility Principle (SRP)
- Clean Architecture
- DTO-Based Communication
- Dependency Injection

Implementation Approach:
------------------------
- Data is retrieved through Stored Procedures only.
- Repository contains no business rules.
- Repository is responsible only for data access.
- Returns List<ProjectStatusDto>.

Why This Repository Exists:
---------------------------
To provide a centralized source for loading project status values such as
Not Started, In Progress, Completed, and any future statuses while
keeping lookup data access separated from business logic.

================================================================================
*/