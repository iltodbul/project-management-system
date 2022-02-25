namespace project_management_system.Models
{
    using System;

    using System.Collections.Generic;

    [Serializable]
    public class Project
    {
        public Project()
        {
            this.Tasks = new List<Task>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Models.Task> Tasks { get; set; }
    }
}
