using Entities;

namespace Shared.Dtos.Task
{
    public record CreateTaskDto(string Code, string Description, Priority Priority, DateOnly StartDate, DateOnly DueDate);

}
