using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessHub.Modules.Identity.Services.RolePermission;
using BusinessHub.Contracts.Identity.Requests.RolePermission;
using BusinessHub.Mappers.Identity.RolePermission;
using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Identity.DTOs.RolePermission;


namespace BusinessHub.API.Controllers.Identity.RolePermission
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly RolePermissionService _service;

        public RolePermissionController(RolePermissionService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(RolePermissionRequest request)
        {
            var dto = RolePermissionMapper.ToDto(request);

            var result = _service.AddRolePermission(dto, "System");

            return Ok(new ApiResponse<int>(true, "Removed", result));
        }

        [HttpPost("remove")]
        public IActionResult Remove(RemoveRolePermissionRequest request)
        {
            var result = _service.RemoveRolePermission(
                request.RoleID,
                request.PermissionID,
                "System"
            );

            return Ok(new ApiResponse<bool>(true, "Removed", result));
        }

        [HttpGet("permissions/{roleId}")]
        public IActionResult GetPermissionsByRoleID(int roleId)
        {
            var data = _service.GetPermissionsByRoleID(roleId);

            return Ok(new ApiResponse<List<PermissionSummaryDto>>(true, "Success", data));
        }

        [HttpGet("roles/{permissionId}")]
        public IActionResult GetRolesByPermissionID(int permissionId)
        {
            var data = _service.GetRolesByPermissionID(permissionId);

            return Ok(new ApiResponse<List<RoleSummaryDto>>(true, "Success", data));
        }
    }
}
