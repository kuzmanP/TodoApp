namespace Services.Interfaces
{
    public interface IServiceManager
    {
        IPersonService PersonService { get; }
        ITaskService TaskService { get; }
    }
}
