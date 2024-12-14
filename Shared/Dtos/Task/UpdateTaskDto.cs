using Entities;

namespace Shared.Dtos.Task
{
    public record UpdateTaskDto(
        string Code,
        string Description,
        Priority Priority,
        DateOnly StartDate,
        DateOnly DueDate);

}
