namespace project_management_system.ViewModels
{
    using System.Collections.Generic;

    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            this.Tasks = new List<TasksViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TasksViewModel> Tasks { get; set; }
    }
}
