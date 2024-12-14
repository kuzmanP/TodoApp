namespace Contracts
{
    public interface IRepositoryManager
    {
        //Fields for Repository
        IPersonRepository PersonRepository { get; }
        ITaskRepository TaskRepository { get; }
       

        void Save();

    }
}
