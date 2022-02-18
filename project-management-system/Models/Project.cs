using System.ComponentModel.DataAnnotations;

namespace project_management_system.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Project
    {
        public Project()
        {
            this.Tasks = new List<Task>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
