using BusinessHub.Contracts.Common;
using BusinessHub.Contracts.Persons.DTOs;
using BusinessHub.Contracts.Persons.Requests;
using BusinessHub.Mappers.Persons;
using BusinessHub.Modules.Persons.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BusinessHub.API.Controllers.Persons
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonService _service;

        public PersonsController(PersonService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(PersonRequestDto person)
        {
            var p = PersonMapper.ToDto(person);

            var result = _service.AddPerson(p, "Admin");
            return Ok(new ApiResponse<int>(true, "Person created", result));
        }

        [HttpPut]
        public IActionResult Update(PersonRequestDto person)
        {
            var p = PersonMapper.ToDto(person);

            var result = _service.UpdatePerson(p, "Admin");

            return Ok(new ApiResponse<bool>(true, "Person Updated", result));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAllPersons();
            return Ok(new ApiResponse<List<PersonDto>>(true, "Success", result));
        }

        [HttpGet("{personId}")]
        public IActionResult GetById(int personId)
        {
            var result = _service.GetPersonById(personId);
            return Ok(new ApiResponse<PersonDto>(true, "Success", result));
        }

        [HttpGet("by-national/{nationalNo}")]
        public IActionResult GetByNationalNo(string nationalNo)
        {
            var result = _service.GetByNationalNo(nationalNo);
            return Ok(new ApiResponse<PersonDto>(true, "Success", result));
        }

        [HttpGet("search/{lastName}")]
        public IActionResult Search(string lastName)
        {
            var result = _service.SearchByLastName(lastName);
            return Ok(new ApiResponse<List<PersonDto>>(true, "Success", result));
        }
    }
}
