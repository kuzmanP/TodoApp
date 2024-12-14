using Contracts;

namespace Repository.Interfaces
{
    public interface IRepositoryManager
    {
        //Fields for Repository
        IPersonRepository PersonRepository { get; }
        ITaskRepository TaskRepository { get; }
       

        void Save();

    }
}
