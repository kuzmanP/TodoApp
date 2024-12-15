
using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Providers
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonService> _personService;
        private readonly Lazy<ITaskService> _taskService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, ILogger<TaskService> logger, ILogger<PersonService> _logger)
        {
            _personService = new Lazy<IPersonService>(() => new PersonService(repositoryManager, mapper,_logger));
            _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, mapper, logger));
        }

        public IPersonService PersonService => _personService.Value;
        public ITaskService TaskService => _taskService.Value;
    }
}
