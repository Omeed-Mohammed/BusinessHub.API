using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Client;
using BusinessHub.Mappers.Core.Client;
using BusinessHub.Modules.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Core.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _service;

        public ClientController(ClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(bool? isActive = null)
        {
            var result = _service.GetAll(isActive);

            return Ok(new ApiResponse<List<ClientDto>>(true, "Success", result));
        }

        [HttpPost]
        public IActionResult Add(CreateClientRequest request)
        {
            var dto = CreateClientMapper.ToDto(request, "Admin");

            var result = _service.Add(dto, "Admin");

            return Ok(new ApiResponse<int>(true, "Client created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateClientRequest request)
        {
            var dto = UpdateClientMapper.ToDto(request, "Admin");

            var result = _service.Update(dto, "Admin");

            return Ok(new ApiResponse<bool>(true, "Client updated", result));
        }

        [HttpGet("company/{companyId:int}")]
        public IActionResult GetByCompanyId(int companyId)
        {
            var result = _service.GetByCompanyId(companyId);

            return Ok(new ApiResponse<List<ClientDto>>(true, "Success", result));
        }

        [HttpGet("{clientId:int}")]
        public IActionResult GetById(int clientId)
        {
            var result = _service.GetById(clientId);

            return Ok(new ApiResponse<ClientDto>(true, "Success", result));
        }

        [HttpPatch("{clientId}/deactivate")]
        public IActionResult Deactivate(int clientId)
        {
            var result = _service.Deactivate(clientId);

            return Ok(new ApiResponse<bool>(true, "Client deactivated", result));
        }

        [HttpPatch("{clientId}/reactivate")]
        public IActionResult Reactivate(int clientId)
        {
            var result = _service.Reactivate(clientId);

            return Ok(new ApiResponse<bool>(true, "Client reactivated", result));
        }
    }
}
