using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPersonRepository> _userRepository;
        private readonly Lazy<ITaskRepository> _taskRepository;
      

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IPersonRepository>(() => new PersonRepository(repositoryContext));
            _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(repositoryContext));
           
        }

        public IPersonRepository PersonRepository => _userRepository.Value;
        public ITaskRepository TaskRepository => _taskRepository.Value;
       

        public void Save()
        {
            Contract.Ensures(_repositoryContext.SaveChanges() >= 0);
            _repositoryContext.SaveChangesAsync();
        }
    }
}
