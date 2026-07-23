using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.Project;
using BusinessHub.Modules.Projects.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _service;

        public ProjectController(ProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateProjectRequestDto request)
        {
            var result = _service.AddProject(request, "Admin");

            return Ok(new ApiResponse<int>(true, "Project created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateProjectRequestDto request)
        {
            var result = _service.UpdateProject(request, "Admin");

            return Ok(new ApiResponse<bool>(true, "Project updated", result));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAllProjects();

            return Ok(new ApiResponse<List<ProjectDto>>(true, "Success", result));
        }

        [HttpGet("{projectID}")]
        public IActionResult GetByID(int projectID)
        {
            var result = _service.GetProjectByID(projectID);

            return Ok(new ApiResponse<ProjectDto>(true, "Success", result));
        }

        [HttpPatch("{projectID}/deactivate")]
        public IActionResult Deactivate(int projectID)
        {
            var result = _service.DeactivateProject(projectID);

            return Ok(new ApiResponse<bool>(true, "Project deactivated", result));
        }

        [HttpPatch("{projectID}/reactivate")]
        public IActionResult Reactivate(int projectID)
        {
            var result = _service.ReactivateProject(projectID);

            return Ok(new ApiResponse<bool>(true, "Project reactivated", result));
        }
    }
}
