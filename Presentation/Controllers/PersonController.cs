using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared.Dtos.Person;
using Shared.Dtos.Task;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PersonController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("AllPersons")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async  Task<IEnumerable<PersonDto>> GetAllPersons(CancellationToken cancellation)
        {
            var getAllPersons =await _serviceManager.PersonService.GetAllPerson(cancellation);
            return getAllPersons;

        }

        [HttpGet("singlePerson")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<PersonDto> GetUniquePerson(Guid Id, CancellationToken cancellation)
        {
            var getSinglePersons =await  _serviceManager.PersonService.GetPersonById(Id, cancellation);
            return getSinglePersons;

        }

        [HttpPut("UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> UpdatePerson(Guid Id, [FromBody] UpdatePersonDto updatePerson, CancellationToken cancellation)
        {
            var result =await _serviceManager.PersonService.UpdatePerson(Id, updatePerson, cancellation);
            return result;

        }

        [HttpPost("CreatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<bool> CreatePerson([FromBody] CreatePersonDto createPerson, CancellationToken cancellation)
        {
            var result =await  _serviceManager.PersonService.CreatePerson(createPerson, cancellation);
            return result;

        }

        [HttpDelete("DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> DeletePerson(Guid Id, CancellationToken cancellation)
        {
            var result =await _serviceManager.PersonService.DeletePerson(Id, cancellation);
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
