using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Identity.DTOs.UserRole;
using BusinessHub.Contracts.Identity.Requests.UserRole;
using BusinessHub.Modules.Identity.Services.UserRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Identity.UserRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly UserRoleService _service;

        public UserRolesController(UserRoleService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public IActionResult Add(UserRoleRequest request)
        {
            var result = _service.AddUserRole(request.UserID, request.RoleID, "System");
            return Ok(new ApiResponse<bool>(result, "Added", result));
        }

        [HttpPost("remove")]
        public IActionResult Remove(UserRoleRequest request)
        {
            var result = _service.RemoveUserRole(request.UserID, request.RoleID, "System");
            return Ok(new ApiResponse<bool>(result, "Removed", result));
        }

        [HttpGet("users/{roleId}")]
        public IActionResult GetUsersByRoleID(int roleId)
        {
            var data = _service.GetUsersByRoleID(roleId);
            return Ok(new ApiResponse<List<UserRoleUserDto>>(true, "Success", data));
        }

        [HttpGet("roles/{userId}")]
        public IActionResult GetRolesByUserID(int userId)
        {
            var data = _service.GetRolesByUserID(userId);
            return Ok(new ApiResponse<List<UserRoleRoleDto>>(true, "Success", data));
        }
    }
}
