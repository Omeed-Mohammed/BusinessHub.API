using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Persons.DTOs;
using BusinessHub.Contracts.Persons.Requests;
using BusinessHub.Mappers.Persons;
using BusinessHub.Modules.Persons.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessHub.API.Controllers.Persons
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhonesController : ControllerBase
    {
        private readonly PersonPhoneService _service;

        public PersonPhonesController(PersonPhoneService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(PersonPhoneRequestDto dto)
        {
            var p = PersonPhoneMapper.ToDto(dto);

            var result = _service.AddPersonPhone(p, "Admin");
            return Ok(new ApiResponse<int>(true, "Phone added", result));
        }

        [HttpGet("{personId}")]
        public IActionResult Get(int personId)
        {
            var result = _service.GetPhonesByPersonID(personId);
            return Ok(new ApiResponse<List<PersonPhoneDto>>(true, "Success", result));
        }

        [HttpDelete("{phoneId}")]
        public IActionResult Delete(int phoneId)
        {
            var result = _service.RemovePersonPhone(phoneId, "Admin");
            return Ok(new ApiResponse<int>(true, "Phone deleted", result));
        }
    }
}
