using System.Diagnostics.Contracts;
using Repository.Interfaces;

namespace Repository.Providers
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
