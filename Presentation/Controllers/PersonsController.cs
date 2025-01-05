using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Dtos.Person;
using Shared.Dtos.Task;
using System.Net.Mime;

namespace Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PersonsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async  Task<IEnumerable<PersonDto>> GetAllPersons(CancellationToken cancellation)
        {
            var getAllPersons =await _serviceManager.PersonService.GetAll(cancellation);
            return getAllPersons;

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<PersonDto?> GetUniquePerson(Guid id, CancellationToken cancellation)
        {
            var getSinglePersons =await  _serviceManager.PersonService.GetById(id, cancellation);
            return getSinglePersons;

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> UpdatePerson(Guid id, [FromBody] UpdatePersonDto updatePerson, CancellationToken cancellation)
        {
            var result =await _serviceManager.PersonService.Update(id, updatePerson, cancellation);
            return result;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonDto))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<bool> CreatePerson([FromBody] CreatePersonDto createPerson, CancellationToken cancellation)
        {
            var result =await  _serviceManager.PersonService.Create(createPerson, cancellation);
            return result;

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<bool> DeletePerson(Guid id, CancellationToken cancellation)
        {
            var result =await _serviceManager.PersonService.Delete(id, cancellation);
            return result;

        }

        [HttpGet("{id}/tasks")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IEnumerable<TaskDto>> AllPersonTasks(Guid id, CancellationToken cancellation)
        {
            var getAllPersons =await  _serviceManager.TaskService.FetchPersonTask(id, cancellation);
            return getAllPersons;

        }
    }
}
