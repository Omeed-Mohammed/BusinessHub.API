using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.ProjectEmployee;
using BusinessHub.Modules.Projects.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController : ControllerBase
    {
        private readonly ProjectEmployeeService _service;

        public ProjectEmployeeController(ProjectEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateProjectEmployeeRequestDto request)
        {
            var result = _service.AddProjectEmployee(request, "Admin");

            return Ok(new ApiResponse<int>(true, "Project employee created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateProjectEmployeeRequestDto request)
        {
            var result = _service.UpdateProjectEmployee(request, "Admin");

            return Ok(new ApiResponse<bool>(true, "Project employee updated", result));
        }

        [HttpGet("{projectEmployeeID}")]
        public IActionResult GetByID(int projectEmployeeID)
        {
            var result = _service.GetProjectEmployeeByID(projectEmployeeID);

            return Ok(new ApiResponse<ProjectEmployeeDto>(true, "Success", result));
        }

        [HttpGet("employee/{employeeID}")]
        public IActionResult GetByEmployeeID(int employeeID)
        {
            var result = _service.GetProjectEmployeeByEmployeeID(employeeID);

            return Ok(new ApiResponse<List<ProjectEmployeeDto>>(true, "Success", result));
        }

        [HttpGet("project/{projectID}")]
        public IActionResult GetByProjectID(int projectID)
        {
            var result = _service.GetProjectEmployeesByProjectID(projectID);

            return Ok(new ApiResponse<List<ProjectEmployeeDto>>(true, "Success", result));
        }

        [HttpPatch("{projectEmployeeID}/deactivate")]
        public IActionResult Deactivate(int projectEmployeeID)
        {
            var result = _service.DeactivateProjectEmployee(projectEmployeeID);

            return Ok(new ApiResponse<bool>(true, "Project employee deactivated", result));
        }

        [HttpPatch("{projectEmployeeID}/reactivate")]
        public IActionResult Reactivate(int projectEmployeeID)
        {
            var result = _service.ReactivateProjectEmployee(projectEmployeeID);

            return Ok(new ApiResponse<bool>(true, "Project employee reactivated", result));
        }
    }
}
