using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.ProjectTask;
using BusinessHub.Modules.Projects.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly ProjectTaskService _service;

        public ProjectTaskController(ProjectTaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateProjectTaskRequestDto request)
        {
            var result = _service.AddProjectTask(request, "Admin");

            return Ok(new ApiResponse<int>(true, "Project task created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateProjectTaskRequestDto request)
        {
            var result = _service.UpdateProjectTask(request, "Admin");

            return Ok(new ApiResponse<bool>(true, "Project task updated", result));
        }

        [HttpGet("{taskID}")]
        public IActionResult GetByID(int taskID)
        {
            var result = _service.GetProjectTaskByID(taskID);

            return Ok(new ApiResponse<ProjectTaskDto>(true, "Success", result));
        }

        [HttpGet("project/{projectID}")]
        public IActionResult GetByProjectID(int projectID)
        {
            var result = _service.GetProjectTasksByProjectID(projectID);

            return Ok(new ApiResponse<List<ProjectTaskDto>>(true, "Success", result));
        }

        [HttpPatch("{taskID}/deactivate")]
        public IActionResult Deactivate(int taskID)
        {
            var result = _service.DeactivateProjectTask(taskID);

            return Ok(new ApiResponse<bool>(true, "Project task deactivated", result));
        }

        [HttpPatch("{taskID}/reactivate")]
        public IActionResult Reactivate(int taskID)
        {
            var result = _service.ReactivateProjectTask(taskID);

            return Ok(new ApiResponse<bool>(true, "Project task reactivated", result));
        }
    }
}
