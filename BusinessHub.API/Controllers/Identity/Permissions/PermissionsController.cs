using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Identity.DTOs.Permissions;
using BusinessHub.Contracts.Identity.Requests.Permissions;
using BusinessHub.Mappers.Identity.Permission;
using BusinessHub.Modules.Identity.Services.Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Identity.Permissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly PermissionService _service;

        public PermissionsController(PermissionService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(PermissionRequest request)
        {
            var dto = PermissionMapper.ToDto(request);

            var result = _service.AddPermission(dto, "System");

            return Ok(new ApiResponse<int>(true, "Permission created", result));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PermissionRequest request)
        {
            var dto = PermissionMapper.ToDto(request);
            dto.PermissionID = id;

            var result = _service.UpdatePermission(dto, "System");

            return Ok(new ApiResponse<bool>(result, "Permission updated", result));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetAllPermissions();
            return Ok(new ApiResponse<List<PermissionDto>>(true, "Success", data));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetPermissionByID(id);
            return Ok(new ApiResponse<PermissionDto>(true, "Success", data));
        }

        [HttpPatch("{id}/deactivate")]
        public IActionResult Deactivate(int id)
        {
            var result = _service.DeactivatePermission(id, "System");
            return Ok(new ApiResponse<bool>(result, "Deactivated", result));
        }

        [HttpPatch("{id}/reactivate")]
        public IActionResult Reactivate(int id)
        {
            var result = _service.ReactivatePermission(id, "System");
            return Ok(new ApiResponse<bool>(result, "Reactivated", result));
        }
    }
}

