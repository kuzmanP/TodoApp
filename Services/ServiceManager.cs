 using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using AutoMapper;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonService> _personService;
        private readonly Lazy<ITaskService> _taskService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _personService = new Lazy<IPersonService>(() => new PersonService(repositoryManager, mapper));
            _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, mapper));
        }

        public IPersonService PersonService => _personService.Value;
        public ITaskService TaskService => _taskService.Value;
    }
}
