using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Company;
using BusinessHub.Mappers.Core.Company;
using BusinessHub.Modules.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Core.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _service;

        public CompanyController(CompanyService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateCompanyRequest request)
        {
            var dto = CreateCompanyMapper.ToDto(request, "Admin");

            var result = _service.AddCompany(dto, "Admin");

            return Ok(new ApiResponse<int>(true, "Company created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateCompanyRequest request)
        {
            var dto = UpdateCompanyMapper.ToDto(request, "Admin");

            var result = _service.UpdateCompany(dto, "Admin");

            return Ok(new ApiResponse<bool>(true, "Company updated", result));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll("Admin");

            return Ok(new ApiResponse<List<CompanyDto>>(true, "Success", result));
        }

        [HttpGet("{companyId}")]
        public IActionResult GetById(int companyId)
        {
            var result = _service.GetCompanyById(companyId, "Admin");

            return Ok(new ApiResponse<CompanyDto>(true, "Success", result));
        }

        [HttpPatch("{companyId}/deactivate")]
        public IActionResult Deactivate(int companyId)
        {
            var result = _service.DeactivateCompany(companyId , "Admin");

            return Ok(new ApiResponse<bool>(true, "Company deactivated", result));
        }

        [HttpPatch("{companyId}/reactivate")]
        public IActionResult Reactivate(int companyId)
        {
            var result = _service.ReactivateCompany(companyId, "Admin");

            return Ok(new ApiResponse<bool>(true, "Company reactivated", result));
        }
    }
}
