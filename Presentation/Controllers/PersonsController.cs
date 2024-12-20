﻿using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Dtos.Person;
using Shared.Dtos.Task;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PersonsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("AllPersons")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async  Task<IEnumerable<PersonDto>> GetAllPersons(CancellationToken cancellation)
        {
            var getAllPersons =await _serviceManager.PersonService.GetAll(cancellation);
            return getAllPersons;

        }

        [HttpGet("singlePerson")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<PersonDto?> GetUniquePerson(Guid Id, CancellationToken cancellation)
        {
            var getSinglePersons =await  _serviceManager.PersonService.GetById(Id, cancellation);
            return getSinglePersons;

        }

        [HttpPut("UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> UpdatePerson(Guid Id, [FromBody] UpdatePersonDto updatePerson, CancellationToken cancellation)
        {
            var result =await _serviceManager.PersonService.Update(Id, updatePerson, cancellation);
            return result;

        }

        [HttpPost("CreatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<bool> CreatePerson([FromBody] CreatePersonDto createPerson, CancellationToken cancellation)
        {
            var result =await  _serviceManager.PersonService.Create(createPerson, cancellation);
            return result;

        }

        [HttpDelete("DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> DeletePerson(Guid Id, CancellationToken cancellation)
        {
            var result =await _serviceManager.PersonService.Delete(Id, cancellation);
            return result;

        }

        [HttpGet("AllPersonTasks")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<IEnumerable<TaskDto>> AllPersonTasks(Guid personId, CancellationToken cancellation)
        {
            var getAllPersons =await  _serviceManager.TaskService.FetchPersonTask(personId, cancellation);
            return getAllPersons;

        }
    }
}
