using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Dtos.Task;
using Shared.Dtos.Person;
using System.Net.Mime;

namespace Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TasksController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TasksController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IEnumerable<TaskDto>> GetAllTasks(CancellationToken cancellation)
        {
            var getAllTasks = await _serviceManager.TaskService.GetAll(cancellation);
            return getAllTasks;

        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status302Found, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<TaskDto?> GetUniqueTask(Guid id, CancellationToken cancellation)
        {
            var getSingleTask = await _serviceManager.TaskService.GetById(id, cancellation);
            return getSingleTask;

        }

        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<bool> UpdateTask(Guid personId, Guid id, [FromBody] UpdateTaskDto updateTask, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.Update(personId, id, updateTask, cancellation);
            return result;

        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<bool> CreateTask(Guid personId,[FromBody] CreateTaskDto createTask, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.Create(personId, createTask, cancellation);
            return result;

        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<bool> DeleteTask(Guid id, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.Delete(id, cancellation);
            return result;

        }


        [HttpGet("{id}/status")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<OkObjectResult> CheckTaskStatus(Guid id, CancellationToken cancellation)
        {
            var result =await _serviceManager.TaskService.CheckStatus(id, cancellation);
            if (result)
            {
                var data = "Task Completed";
                return Ok(data);
            }

            var data1 = "Not Completed";
            return Ok(data1);
        }

        [HttpGet("{id}/setStatus")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<OkObjectResult> SetTaskStatus(Guid id, int setCode, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.SetStatus(id, setCode, cancellation);
            if (result)
            {
                var data = "Task Status set";
                return Ok(data);
            }

            var data1 = "Not Set";
            return Ok(data1);
        }


        [HttpGet("AllOverDueTasks")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public  IEnumerable<TaskDto> AllOverDueTasks(CancellationToken cancellation)
        {
            var getAllOverDueTask = _serviceManager.TaskService.GetAllOverdueTask(cancellation);
            return getAllOverDueTask;

        }
    }
}
