using Entities;

namespace Shared.Dtos.Task
{
    public record TaskDto( string Code , string Description, Priority Priority , DateOnly DateCreated, DateOnly StartDate, DateOnly DueDate);

}
