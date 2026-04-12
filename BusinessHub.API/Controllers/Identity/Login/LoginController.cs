using BusinessHub.Contracts.Common;
using BusinessHub.Mappers.Identity.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessHub.Contracts.Identity.Requests.Login;
using BusinessHub.Modules.Identity.Services.Login;

namespace BusinessHub.API.Controllers.Identity.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginServices _service;

        public LoginController(LoginServices service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var dto = LoginMapper.ToDto(request);

            var result = _service.LoginRequest(dto, "System");

            return Ok(new ApiResponse<bool>(result, result ? "Login success" : "Invalid credentials", result));
        }
    }
}

