using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Interfaces;
using BusinessHub.Contracts.Projects.Requests.ProjectTask;
using BusinessHub.Mappers.Projects.ProjectTask;
using BusinessHub.Validators.Projects.ProjectTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Projects.Services
{
    public class ProjectTaskService
    {
        private readonly IProjectTaskRepository _repo;

        public ProjectTaskService(IProjectTaskRepository repo)
        {
            _repo = repo;
        }

        public int AddProjectTask(CreateProjectTaskRequestDto request, string currentUser)
        {
            if (request == null)
                throw new ArgumentException("Invalid data");

            var validator = new CreateProjectTaskValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.First().ErrorMessage);

            var dto = CreateProjectTaskMapper.ToDto(request, currentUser);

            return _repo.AddProjectTask(dto, currentUser);
        }

        public bool UpdateProjectTask(UpdateProjectTaskRequestDto request, string currentUser)
        {
            if (request == null)
                throw new ArgumentException("Invalid data");

            var validator = new UpdateProjectTaskValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.First().ErrorMessage);

            var dto = UpdateProjectTaskMapper.ToDto(request, currentUser);

            return _repo.UpdateProjectTask(dto, currentUser);
        }

        public ProjectTaskDto GetProjectTaskByID(int taskID)
        {
            if (taskID <= 0)
                throw new ArgumentException("Invalid TaskID");

            var task = _repo.GetProjectTaskByID(taskID);

            if (task == null)
                throw new KeyNotFoundException("ProjectTask not found");

            return task;
        }

        public List<ProjectTaskDto> GetProjectTasksByProjectID(int projectID)
        {
            if (projectID <= 0)
                throw new ArgumentException("Invalid ProjectID");

            return _repo.GetProjectTasksByProjectID(projectID)
                ?? new List<ProjectTaskDto>();
        }

        public bool DeactivateProjectTask(int taskID)
        {
            if (taskID <= 0)
                throw new ArgumentException("Invalid TaskID");

            return _repo.DeactivateProjectTask(taskID);
        }

        public bool ReactivateProjectTask(int taskID)
        {
            if (taskID <= 0)
                throw new ArgumentException("Invalid TaskID");

            return _repo.ReactivateProjectTask(taskID);
        }
    }
}
