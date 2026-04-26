using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.CompanySettings;
using BusinessHub.Mappers.Core.CompanySettings;
using BusinessHub.Modules.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Core.CompanySettings
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanySettingsController : ControllerBase
    {
        private readonly CompanySettingsService _service;

        public CompanySettingsController(CompanySettingsService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateCompanySettingsRequest request)
        {
            var dto = CreateCompanySettingsMapper.ToDto(request, "Admin");

            var result = _service.Add(dto, "Admin");

            return Ok(new ApiResponse<bool>(true, "Settings created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateCompanySettingsRequest request)
        {
            var dto = UpdateCompanySettingsMapper.ToDto(request, "Admin");

            var result = _service.Update(dto, "Admin");

            return Ok(new ApiResponse<bool>(true, "Settings updated", result));
        }

        [HttpGet("{companyId}")]
        public IActionResult GetByCompanyId(int companyId)
        {
            var result = _service.GetByCompanyId(companyId);

            return Ok(new ApiResponse<CompanySettingsDto>(true, "Success", result));
        }
    }
}
