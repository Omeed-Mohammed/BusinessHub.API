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
    public class PersonNotesController : ControllerBase
    {
        private readonly PersonNoteService _service;

        public PersonNotesController(PersonNoteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(PersonNoteRequestDto dto)
        {
            var p = PersonNoteMapper.ToDto(dto);

            var result = _service.AddPersonNote(p, "Admin");
            return Ok(new ApiResponse<int>(true, "Note added", result));
        }

        [HttpGet("{personId}")]
        public IActionResult Get(int personId)
        {
            var data = _service.GetNoteByPersonID(personId);
            return Ok(new ApiResponse<List<PersonNoteDto>>(true, "Success", data));
        }
    }
}
