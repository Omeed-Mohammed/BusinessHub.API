using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Identity.DTOs.Roles;
using BusinessHub.Contracts.Identity.Requests.Roles;
using BusinessHub.Mappers.Identity.Roles;
using BusinessHub.Modules.Identity.Services.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Identity.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _service;

        public RolesController(RoleService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(RoleRequest request)
        {
            var dto = RoleMapper.ToDto(request);

            var result = _service.AddRole(dto, "System");

            return Ok(new ApiResponse<int>(true, "Role created", result));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RoleRequest request)
        {
            var dto = RoleMapper.ToDto(request);
            dto.RoleID = id;

            var result = _service.UpdateRole(dto, "System");

            return Ok(new ApiResponse<bool>(true, "Role updated", result));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetAllRoles();

            return Ok(new ApiResponse<List<RoleDto>>(true, "Success", data));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetRoleByID(id);

            return Ok(new ApiResponse<RoleDto>(true, "Success", data));
        }

        [HttpPatch("{id}/deactivate")]
        public IActionResult Deactivate(int id)
        {
            var result = _service.DeactivateRole(id, "System");

            return Ok(new ApiResponse<bool>(true, "Deactivated", result));
        }

        [HttpPatch("{id}/reactivate")]
        public IActionResult Reactivate(int id)
        {
            var result = _service.ReactivateRole(id, "System");

            return Ok(new ApiResponse<bool>(true, "Reactivated", result));
        }

    }
}
