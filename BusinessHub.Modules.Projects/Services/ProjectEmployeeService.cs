using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Interfaces;
using BusinessHub.Contracts.Projects.Requests.ProjectEmployee;
using BusinessHub.Mappers.Projects.ProjectEmployee;
using BusinessHub.Validators.Projects.ProjectEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Projects.Services
{
    public class ProjectEmployeeService
    {
        private readonly IProjectEmployeeRepository _repo;

        public ProjectEmployeeService(IProjectEmployeeRepository repo)
        {
            _repo = repo;
        }

        public int AddProjectEmployee(CreateProjectEmployeeRequestDto request, string currentUser)
        {
            if (request == null)
                throw new ArgumentException("Invalid data");

            var validator = new CreateProjectEmployeeValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.First().ErrorMessage);

            var dto = CreateProjectEmployeeMapper.ToDto(request, currentUser);

            return _repo.AddProjectEmployee(dto, currentUser);
        }

        public bool UpdateProjectEmployee(UpdateProjectEmployeeRequestDto request, string currentUser)
        {
            if (request == null)
                throw new ArgumentException("Invalid data");

            var validator = new UpdateProjectEmployeeValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.First().ErrorMessage);

            var dto = UpdateProjectEmployeeMapper.ToDto(request, currentUser);

            return _repo.UpdateProjectEmployee(dto, currentUser);
        }

        public ProjectEmployeeDto GetProjectEmployeeByID(int projectEmployeeID)
        {
            if (projectEmployeeID <= 0)
                throw new ArgumentException("Invalid ProjectEmployeeID");

            var employee = _repo.GetProjectEmployeeByID(projectEmployeeID);

            if (employee == null)
                throw new KeyNotFoundException("ProjectEmployee not found");

            return employee;
        }

        public List<ProjectEmployeeDto> GetProjectEmployeeByEmployeeID(int employeeID)
        {
            if (employeeID <= 0)
                throw new ArgumentException("Invalid EmployeeID");

            return _repo.GetProjectEmployeeByEmployeeID(employeeID)
                ?? new List<ProjectEmployeeDto>();
        }

        public List<ProjectEmployeeDto> GetProjectEmployeesByProjectID(int projectID)
        {
            if (projectID <= 0)
                throw new ArgumentException("Invalid ProjectID");

            return _repo.GetProjectEmployeesByProjectID(projectID)
                ?? new List<ProjectEmployeeDto>();
        }

        public bool DeactivateProjectEmployee(int projectEmployeeID)
        {
            if (projectEmployeeID <= 0)
                throw new ArgumentException("Invalid ProjectEmployeeID");

            return _repo.DeactivateProjectEmployee(projectEmployeeID);
        }

        public bool ReactivateProjectEmployee(int projectEmployeeID)
        {
            if (projectEmployeeID <= 0)
                throw new ArgumentException("Invalid ProjectEmployeeID");

            return _repo.ReactivateProjectEmployee(projectEmployeeID);
        }
    }
}
