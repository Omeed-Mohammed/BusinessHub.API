using BusinessHub.Contracts.Projects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Interfaces
{
    public interface IProjectTaskRepository
    {
        int AddProjectTask(ProjectTaskDto projectTask, string currentUser);

        bool UpdateProjectTask(ProjectTaskDto projectTask, string currentUser);

        ProjectTaskDto? GetProjectTaskByID(int taskID);

        List<ProjectTaskDto> GetProjectTasksByProjectID(int projectID);

        bool DeactivateProjectTask(int taskID);

        bool ReactivateProjectTask(int taskID);
    }
}
