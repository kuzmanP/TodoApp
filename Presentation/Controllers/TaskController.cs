using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Dtos.Task;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TaskController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("AllTasks")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<IEnumerable<TaskDto>> GetAllTasks(CancellationToken cancellation)
        {
            var getAllTasks = await _serviceManager.TaskService.GetAll(cancellation);
            return getAllTasks;

        }

        [HttpGet("singleTask")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<TaskDto> GetUniqueTask(Guid taskId, CancellationToken cancellation)
        {
            var getSingleTask = await _serviceManager.TaskService.GetById(taskId, cancellation);
            return getSingleTask;

        }

        [HttpPut("UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> UpdateTask(Guid personId, Guid taskId, [FromBody] UpdateTaskDto updateTask, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.Update(personId, taskId, updateTask, cancellation);
            return result;

        }

        [HttpPost("CreateTask")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<bool> CreateTask(Guid personId,[FromBody] CreateTaskDto createTask, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.Create(personId, createTask, cancellation);
            return result;

        }

        [HttpDelete("DeleteTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> DeleteTask(Guid taskId, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.Delete(taskId, cancellation);
            return result;

        }


        [HttpGet("checkTaskStatus")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<OkObjectResult> CheckTaskStatus(Guid taskId, CancellationToken cancellation)
        {
            var result =await _serviceManager.TaskService.CheckStatus(taskId, cancellation);
            if (result)
            {
                var data = "Task Completed";
                return Ok(data);
            }

            var data1 = "Not Completed";
            return Ok(data1);
        }

        [HttpGet("setTaskStatus")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<OkObjectResult> SetTaskStatus(Guid taskId, int setCode, CancellationToken cancellation)
        {
            var result = await _serviceManager.TaskService.SetStatus(taskId, setCode, cancellation);
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
