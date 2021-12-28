using Application.Dtos.Person.Requests;
using Application.Dtos.Person.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Produces(typeof(GetAllPersonsDtoResponse))]
        public async Task<IActionResult> GetAll()
        {
            var response = await _personService.GetAllAsync();

            return SendResponse(response);
        }

        [HttpGet]
        [Route("{id}")]
        [Produces(typeof(GetPersonByIdDtoResponse))]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _personService.GetByIdAsync(id);

            return SendResponse(response);
        }

        [HttpPost]
        [Produces(typeof(CreatePersonDtoResponse))]
        public async Task<IActionResult> Create([FromBody] CreatePersonDtoRequest dto)
        {
            var response = await _personService.CreateAsync(dto);

            return SendResponse(response);
        }

        [HttpPut]
        [Route("{id}")]
        [Produces(typeof(UpdatePersonByIdDtoResponse))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonByIdDtoRequest dto)
        {
            var response = await _personService.UpdateByIdAsync(id, dto);

            return SendResponse(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _personService.DeleteByIdAsync(id);

            return SendResponse(response);
        }
    }
}
