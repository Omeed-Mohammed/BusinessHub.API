using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Branch;
using BusinessHub.Mappers.Core.Branch;
using BusinessHub.Modules.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Core.Branch
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly BranchService _service;

        public BranchController(BranchService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateBranchRequest request)
        {
            var dto = CreateBranchMapper.ToDto(request, "Admin");

            var result = _service.Add(dto, "Admin");

            return Ok(new ApiResponse<int>(true, "Branch created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateBranchRequest request)
        {
            var dto = UpdateBranchMapper.ToDto(request, "Admin");

            var result = _service.Update(dto, "Admin");

            return Ok(new ApiResponse<bool>(true, "Branch updated", result));
        }

        [HttpGet("company/{companyId:int}")]
        public IActionResult GetByCompanyId(int companyId)
        {
            var result = _service.GetByCompanyId(companyId);

            return Ok(new ApiResponse<List<BranchDto>>(true, "Success", result));
        }

        [HttpGet("{branchId:int}")]
        public IActionResult GetById(int branchId)
        {
            var result = _service.GetById(branchId);

            return Ok(new ApiResponse<BranchDto>(true, "Success", result));
        }

        [HttpPatch("{branchId}/deactivate")]
        public IActionResult Deactivate(int branchId)
        {
            var result = _service.Deactivate(branchId);

            return Ok(new ApiResponse<bool>(true, "Branch deactivated", result));
        }

        [HttpPatch("{branchId}/reactivate")]
        public IActionResult Reactivate(int branchId)
        {
            var result = _service.Reactivate(branchId);

            return Ok(new ApiResponse<bool>(true, "Branch reactivated", result));
        }
    }
}
