using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Task
{
    public record CreateTaskDto(string Code, string Description, Priority Priority, DateOnly StartDate, DateOnly DueDate);

}
