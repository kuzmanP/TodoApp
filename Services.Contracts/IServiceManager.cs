namespace Services.Contracts
{
    public interface IServiceManager
    {
        IPersonService PersonService { get; }
        ITaskService TaskService { get; }
    }
}
