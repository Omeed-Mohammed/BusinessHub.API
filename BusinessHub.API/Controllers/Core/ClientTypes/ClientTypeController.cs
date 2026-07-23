using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.ClientTypes;
using BusinessHub.Mappers.Core.ClientTypes;
using BusinessHub.Modules.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Core.ClientTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTypeController : ControllerBase
    {
        private readonly ClientTypeService _service;

        public ClientTypeController(ClientTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(bool? isActive = null)
        {
            var result = _service.GetAll(isActive);

            return Ok(new ApiResponse<List<ClientTypeDto>>(true, "Success", result));
        }

        [HttpGet("{clientTypeId:int}")]
        public IActionResult GetById(int clientTypeId)
        {
            var result = _service.GetById(clientTypeId);

            return Ok(new ApiResponse<ClientTypeDto>(true, "Success", result));
        }

        [HttpPost]
        public IActionResult Add(CreateClientTypeRequest request)
        {
            var dto = CreateClientTypeMapper.ToDto(request, "Admin");

            var result = _service.Add(dto, "Admin");

            return Ok(new ApiResponse<int>(true, "ClientType created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateClientTypeRequest request)
        {
            var dto = UpdateClientTypeMapper.ToDto(request, "Admin");

            var result = _service.Update(dto, "Admin");

            return Ok(new ApiResponse<bool>(true, "ClientType updated", result));
        }

        [HttpPatch("{clientTypeId:int}/deactivate")]
        public IActionResult Deactivate(int clientTypeId)
        {
            var result = _service.Deactivate(clientTypeId);

            return Ok(new ApiResponse<bool>(true, "ClientType deactivated", result));
        }

        [HttpPatch("{clientTypeId:int}/reactivate")]
        public IActionResult Reactivate(int clientTypeId)
        {
            var result = _service.Reactivate(clientTypeId);

            return Ok(new ApiResponse<bool>(true, "ClientType reactivated", result));
        }
    }
}
