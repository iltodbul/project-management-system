using project_management_system.Models.Enums;

namespace project_management_system.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Assignee { get; set; }

        public TaskType TaskType { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        public int Estimate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
