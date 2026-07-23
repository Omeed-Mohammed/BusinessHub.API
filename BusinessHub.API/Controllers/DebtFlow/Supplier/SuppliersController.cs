using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.DebtFlow.DTOs.Supplier;
using BusinessHub.Contracts.DebtFlow.Requests.Supplier;
using BusinessHub.Mappers.DebtFlow.Supplier;
using BusinessHub.Modules.DebtFlow.Services.Supplier;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.DebtFlow.Supplier
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _service;

        public SuppliersController(SupplierService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(CreateSupplierRequestDto request)
        {
            var dto = SupplierMapper.CreateToDto(
                request,
                companyID: 1,
                currentUser: "Admin");

            var result = _service.AddSupplier(dto);

            return Ok(new ApiResponse<int>(true, "Supplier created", result));
        }

        [HttpPut]
        public IActionResult Update(UpdateSupplierRequestDto request)
        {
            var dto = SupplierMapper.UpdateToDto(
                request,
                currentUser: "Admin");

            var result = _service.UpdateSupplier(dto);

            return Ok(new ApiResponse<bool>(true, "Supplier updated", result));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAllSuppliers();

            return Ok(new ApiResponse<List<SupplierDto>>(true, "Success", result));
        }

        [HttpGet("{supplierID}")]
        public IActionResult GetByID(int supplierID)
        {
            var result = _service.GetSupplierById(supplierID);

            return Ok(new ApiResponse<SupplierDto?>(true, "Success", result));
        }

        [HttpPatch("{supplierID}/deactivate")]
        public IActionResult Deactivate(int supplierID)
        {
            var result = _service.DeactivateSupplier(
                supplierID,
                "Admin");

            return Ok(new ApiResponse<bool>(true, "Supplier deactivated", result));
        }

        [HttpPatch("{supplierID}/reactivate")]
        public IActionResult Reactivate(int supplierID)
        {
            var result = _service.ReactivateSupplier(
                supplierID,
                "Admin");

            return Ok(new ApiResponse<bool>(true, "Supplier reactivated", result));
        }
    }
}
