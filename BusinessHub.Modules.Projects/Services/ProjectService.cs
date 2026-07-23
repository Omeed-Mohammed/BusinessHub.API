using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Interfaces;
using BusinessHub.Contracts.Projects.Requests.Project;
using BusinessHub.Mappers.Projects.Project;
using BusinessHub.Validators.Projects.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Projects.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _repo;

        public ProjectService(IProjectRepository repo)
        {
            _repo = repo;
        }


        public int AddProject(CreateProjectRequestDto request, string currentUser)
        {
            if (request == null)
                throw new ArgumentException("Invalid data");

            var validator = new CreateProjectValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.First().ErrorMessage);

            var projectDto = CreateProjectMapper.ToDto(request, currentUser);

            return _repo.AddProject(projectDto, currentUser);
        }

        public bool UpdateProject(UpdateProjectRequestDto request, string currentUser)
        {
            if (request == null)
                throw new ArgumentException("Invalid data");

            var validator = new UpdateProjectValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.First().ErrorMessage);

            var projectDto = UpdateProjectMapper.ToDto(request, currentUser);

            return _repo.UpdateProject(projectDto, currentUser);
        }

        public List<ProjectDto> GetAllProjects()
        {
            return _repo.GetAllProjects() ?? new List<ProjectDto>();
        }

        public ProjectDto GetProjectByID(int projectID)
        {
            if (projectID <= 0)
                throw new ArgumentException("Invalid ProjectID");

            var project = _repo.GetProjectByID(projectID);

            if (project == null)
                throw new KeyNotFoundException("Project not found");

            return project;
        }

        public bool DeactivateProject(int projectID)
        {
            if (projectID <= 0)
                throw new ArgumentException("Invalid ProjectID");

            return _repo.DeactivateProject(projectID);
        }

        public bool ReactivateProject(int projectID)
        {
            if (projectID <= 0)
                throw new ArgumentException("Invalid ProjectID");

            return _repo.ReactivateProject(projectID);
        }

    }
}
