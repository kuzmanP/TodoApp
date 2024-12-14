using Contracts;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services.Providers
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonService> _personService;
        private readonly Lazy<ITaskService> _taskService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, ILogger<TaskService> logger)
        {
            _personService = new Lazy<IPersonService>(() => new PersonService(repositoryManager, mapper));
            _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, mapper, logger));
        }

        public IPersonService PersonService => _personService.Value;
        public ITaskService TaskService => _taskService.Value;
    }
}
