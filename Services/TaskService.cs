using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Services.Contracts;
using Shared.Dtos.Person;
using Shared.Dtos.Task;

namespace Services
{
    public class TaskService:ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TaskService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TaskDto>> GetAllTasks(CancellationToken cancellationToken)
        {
            var getTasks = await _repositoryManager.TaskRepository.GetAllTasksAsync(cancellationToken);
            var getTasksOut = _mapper.Map<IEnumerable<TaskDto>>(getTasks);
            return getTasksOut;
        }

        public async Task<TaskDto> GetTaskById(Guid taskId, CancellationToken cancellationToken)
        {
            var uniqueTask = await _repositoryManager.TaskRepository.GetUniqueTasksAsync(taskId, cancellationToken);
            var uniqueTaskOut = _mapper.Map<TaskDto>(uniqueTask);
            return uniqueTaskOut;
        }

        public async Task<bool> UpdateTask(Guid personId, Guid taskId, UpdateTaskDto task,
            CancellationToken cancellationToken)
        {
            var personEntity =
                await _repositoryManager.PersonRepository.GetUniquePersonAsync(personId, cancellationToken);
            if (personEntity != null)
            {
                var taskEntity = await _repositoryManager.TaskRepository.GetUniqueTasksAsync(taskId, cancellationToken);
                var taskEntityDto = _mapper.Map(task, taskEntity);
                try
                {
                    var updateTask =
                        await _repositoryManager.TaskRepository.UpdateTasksAsync(taskEntityDto, cancellationToken);
                    _repositoryManager.Save();
                    return updateTask;
                }
                catch (Exception)
                {
                    return false;

                }
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> CreateTask(Guid personId, CreateTaskDto createTask, CancellationToken cancellationToken)
        {
           
            var personEntity = await _repositoryManager.PersonRepository.GetUniquePersonAsync(personId, cancellationToken);
            if (personEntity == null)
            {
                throw new ArgumentException("Person not found.");
            }
            var entity = _mapper.Map<Person>(personEntity);
            if (entity.Task == null)
            {
                entity.Task = new List<Tasks>();
            }
            var taskEntity = _mapper.Map<Tasks>(createTask);
            if (taskEntity == null)
            {
                throw new InvalidOperationException("Task entity could not be mapped.");
            }
            taskEntity.PersonId = personId;
            entity.Task.Add(taskEntity);
            var createTaskEntity = await _repositoryManager.TaskRepository.CreateTasksAsync(taskEntity, cancellationToken);
             _repositoryManager.Save();

            return true;
        }



        public async Task<bool> DeleteTask(Guid taskId, CancellationToken cancellationToken)
        {
            var deleteEntity = await _repositoryManager.TaskRepository.DeleteTasksAsync(taskId, cancellationToken);
            _repositoryManager.Save();
            return true;
        }

        public async Task<bool> CheckTaskStatus(Guid taskId, CancellationToken cancellationToken)
        {
            var taskStatus =await _repositoryManager.TaskRepository.GetUniqueTasksAsync(taskId,cancellationToken);
            if (!taskStatus.IsCompleted == true )
            {
                return false;
            }

            return true;
        }

        public async Task<bool> SetTaskStatus(Guid taskId, int setCode, CancellationToken cancellationToken)
        {
            var getTask =await _repositoryManager.TaskRepository.GetUniqueTasksAsync(taskId, cancellationToken);
            if (setCode == 1)
            {
                getTask.IsCompleted = true;
                await _repositoryManager.TaskRepository.UpdateTasksAsync(getTask, cancellationToken);
                _repositoryManager.Save();
                return true;
            }
            getTask.IsCompleted = false;
                await _repositoryManager.TaskRepository.UpdateTasksAsync(getTask, cancellationToken);
            _repositoryManager.Save();
            return false;
        }

        public  IEnumerable<TaskDto> GetAllOverdueTask(CancellationToken cancellation)
        {
            var overDueTasks =  _repositoryManager.TaskRepository.GetAllTasksAsync(cancellation).Result
                .Where(o => o.DueDate < DateOnly.FromDateTime(DateTime.UtcNow));
            var overdueToOutput = _mapper.Map<IEnumerable<TaskDto>>(overDueTasks);
            return overdueToOutput;
        }

        public async Task<IEnumerable<TaskDto>> FetchPersonTask(Guid personId, CancellationToken cancellation)
        {
            var personEntity =await  _repositoryManager.PersonRepository.GetUniquePersonAsync(personId, cancellation);
            if (personEntity == null)
            {
                throw new ArgumentException("Person not found.");
            }

            var personTasks = await _repositoryManager.TaskRepository.GetAllTasksAsync(cancellation);
            var personTaskOut = _mapper.Map <IEnumerable<TaskDto>>(personTasks.Where(p => p.PersonId.Equals(personId)));
            return personTaskOut;
        }
    }
    
}
