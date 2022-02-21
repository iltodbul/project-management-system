namespace project_management_system.Models
{
    using System.Collections.Generic;

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
