using BusinessHub.Contracts.Projects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Interfaces
{
    public interface IProjectRepository
    {
        int AddProject(ProjectDto project, string currentUser);

        bool UpdateProject(ProjectDto project, string currentUser);

        List<ProjectDto> GetAllProjects();

        ProjectDto? GetProjectByID(int projectID);

        bool DeactivateProject(int projectID);

        bool ReactivateProject(int projectID);
    }
}
