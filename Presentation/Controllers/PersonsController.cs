using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Dtos.Person;
using Shared.Dtos.Task;
using System.Net.Mime;
using Shared.Responses;

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
        public async  Task<IEnumerable<ApiResponse<PersonDto>>> GetAllPersons(CancellationToken cancellation)
        {
            try
            {
                var getAllPersons = await _serviceManager.PersonService.GetAll(cancellation);
                return getAllPersons.Select(person => ApiResponse<PersonDto>.SuccessResponse(person));
            }
            catch (Exception ex)
            {

                return new List<ApiResponse<PersonDto>>()
                {
                    ApiResponse<PersonDto>.ErrorResponse(ex.Message,$"{ex.Message}")
                };

            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<ApiResponse<PersonDto>> GetUniquePerson(Guid id, CancellationToken cancellation)
        {
            try
            {
                var getSinglePersons = await _serviceManager.PersonService.GetById(id, cancellation);
                if (getSinglePersons != null)
                {
                    return ApiResponse<PersonDto>.SuccessResponse(getSinglePersons);
                }
                
                return ApiResponse<PersonDto>.ErrorResponse("Not Found");
            }
            catch (Exception ex)
            {

                return ApiResponse<PersonDto>.ErrorResponse(ex.Message, $"{ex.Message}");

            }
           
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ApiResponse<bool>> UpdatePerson(Guid id, [FromBody] UpdatePersonDto updatePerson, CancellationToken cancellation)
        {
            try
            {
                var result = await _serviceManager.PersonService.Update(id, updatePerson, cancellation);
                return ApiResponse<bool>.SuccessResponse(result);
            }
            catch (Exception  ex)
            {

                return ApiResponse<bool>.ErrorResponse(ex.Message,$"{ex.Message}");
            }
            

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonDto))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ApiResponse<bool>> CreatePerson([FromBody] CreatePersonDto createPerson, CancellationToken cancellation)
        {
            try
            {
                var result = await _serviceManager.PersonService.Create(createPerson, cancellation);
                return ApiResponse<bool>.SuccessResponse(result);
            }
            catch (Exception ex)
            {

                return ApiResponse<bool>.ErrorResponse(ex.Message,$"{ex.Message}");
            }
            

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<ApiResponse<bool>> DeletePerson(Guid id, CancellationToken cancellation)
        {
            try
            {
                var result = await _serviceManager.PersonService.Delete(id, cancellation);
                return ApiResponse<bool>.SuccessResponse(result);
            }
            catch (Exception ex)
            {

                return ApiResponse<bool>.ErrorResponse(ex.Message);
            }
           

        }

        [HttpGet("{id}/tasks")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IEnumerable<ApiResponse<TaskDto>>> AllPersonTasks(Guid id, CancellationToken cancellation)
        {
            try
            {
                var getAllPersons = await _serviceManager.TaskService.FetchPersonTask(id, cancellation);
                return getAllPersons.Select(task => ApiResponse<TaskDto>.SuccessResponse(task));
            }
            catch (Exception ex)
            {

                return new List<ApiResponse<TaskDto>>()
                {
                    ApiResponse<TaskDto>.ErrorResponse(ex.Message,$"{ex.Message}")
                };
            }
            

        }
    }
}
