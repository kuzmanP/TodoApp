using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
