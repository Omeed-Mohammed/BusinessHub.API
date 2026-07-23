using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Modules.Projects.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusController : ControllerBase
    {
        private readonly ProjectStatusService _service;

        public ProjectStatusController(ProjectStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAllProjectStatus();

            return Ok(new ApiResponse<List<ProjectStatusDto>>(true, "Success", result));
        }
    }
}
