using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Dtos.Task;
using System.Net.Mime;
using Shared.Responses;

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
        public async Task<IEnumerable<ApiResponse<TaskDto>>> GetAllTasks(CancellationToken cancellation)
        {
            try
            {
                var getAllTasks = await _serviceManager.TaskService.GetAll(cancellation);
                return getAllTasks.Select(task => ApiResponse<TaskDto>.SuccessResponse(task));
            }
            catch (Exception ex)
            {

                return new List<ApiResponse<TaskDto>>()
                {
                    ApiResponse<TaskDto>.ErrorResponse(ex.Message)
                };
            }           

        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status302Found, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<ApiResponse<TaskDto?>> GetUniqueTask(Guid id, CancellationToken cancellation)
        {
            try
            {
                var getSingleTask = await _serviceManager.TaskService.GetById(id, cancellation);
                return ApiResponse<TaskDto?>.SuccessResponse(getSingleTask);
            }
            catch (Exception ex)
            {

                return ApiResponse<TaskDto?>.ErrorResponse(ex.Message);
            }

        }

        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ApiResponse<bool>> UpdateTask(Guid personId, Guid id, [FromBody] UpdateTaskDto updateTask, CancellationToken cancellation)
        {
            try
            {
                var result = await _serviceManager.TaskService.Update(personId, id, updateTask, cancellation);
                return ApiResponse<bool>.SuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(ex.Message);
            }

        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ApiResponse<bool>> CreateTask(Guid personId,[FromBody] CreateTaskDto createTask, CancellationToken cancellation)
        {
            try
            {
                var result = await _serviceManager.TaskService.Create(personId, createTask, cancellation);
                return ApiResponse<bool>.SuccessResponse(result);
            }
            catch (Exception ex)
            {

               return ApiResponse<bool>.ErrorResponse(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ApiResponse<bool>> DeleteTask(Guid id, CancellationToken cancellation)
        {
            try
            {
                var result = await _serviceManager.TaskService.Delete(id, cancellation);
                return ApiResponse<bool>.SuccessResponse(result);
            }
            catch (Exception ex)
            {

               return ApiResponse<bool>.ErrorResponse(ex.Message);
            }

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
        public  IEnumerable<ApiResponse<TaskDto>> AllOverDueTasks(CancellationToken cancellation)
        {
            try
            {
                var getAllOverDueTask = _serviceManager.TaskService.GetAllOverdueTask(cancellation);
                return getAllOverDueTask.Select(allTasks => ApiResponse<TaskDto>.SuccessResponse(allTasks));
            }
            catch (Exception ex)
            {

                return new List<ApiResponse<TaskDto>>()
                {
                    ApiResponse<TaskDto>.ErrorResponse(ex.Message)
                };
            }

        }
    }
}
