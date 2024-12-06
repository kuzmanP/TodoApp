using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tasks
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly DueDate { get; set; }
        public Guid PersonId { get; set; }  
        public Person Person { get; set; }  
        public bool IsCompleted { get; set; }

        public Tasks()
        {
            Priority= Priority.Medium;
            DateCreated = DateOnly.FromDateTime(DateTime.UtcNow);
            IsCompleted = false;
        }


    }


    public enum Priority
    {
        Urgent,
        Important,
        Medium,
        Less
    }
}
