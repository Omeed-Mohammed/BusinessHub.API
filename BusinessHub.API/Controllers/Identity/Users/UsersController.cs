using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Identity.DTOs.Users;
using BusinessHub.Contracts.Identity.Requests.Users;
using BusinessHub.Mappers.Identity.Users;
using BusinessHub.Modules.Identity.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Identity.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string _currentUser = "Admin";
        private readonly UserServices _service;

        public UsersController(UserServices service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateUserRequest request)
        {
            var dto = UserMapper.ToDto(request, "System");
            var result = _service.AddUser(dto, _currentUser);

            return Ok(new ApiResponse<int>(true, "User created", result));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetAllUsers();

            return Ok(new ApiResponse<List<UserDto>>(true, "Success", data));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetUserByID(id);

            return Ok(new ApiResponse<UserDto>(true, "Success", data));
        }

        [HttpGet("by-username/{username}")]
        public IActionResult GetByUsername(string username)
        {
            var data = _service.GetUserByUsername(username);

            return Ok(new ApiResponse<UserDto>(true, "Success", data));
        }

        [HttpPost("change-password")]
        public IActionResult ChangePassword(ChangePasswordRequest request)
        {
            var dto = UserMapper.ToDto(request);
            var result = _service.ChangePassword(dto, _currentUser);

            return Ok(new ApiResponse<bool>(true, "Password changed", result));
        }

        [HttpPatch("{id}/deactivate")]
        public IActionResult Deactivate(int id)
        {
            var result = _service.DeactivateUser(id, "System");

            return Ok(new ApiResponse<bool>(true, "User deactivated", result));
        }

        [HttpPatch("{id}/reactivate")]
        public IActionResult Reactivate(int id)
        {
            var result = _service.ReactivateUser(id, "System");

            return Ok(new ApiResponse<bool>(true, "User reactivated", result));
        }
    }
}
