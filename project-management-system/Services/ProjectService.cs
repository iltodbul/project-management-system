namespace project_management_system.Services
{
    using JsonFlatFileDataStore;

    using System.Collections.Generic;
    using System.Linq;

    using project_management_system.Extensions;
    using project_management_system.Models;
    using project_management_system.ViewModels;

    public class ProjectService : IProjectService
    {
        private readonly IDataStore _ds;

        public ProjectService(IDataStore ds)
        {
            _ds = ds;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var projects = _ds.GetCollection<Project>("projects").AsQueryable().ToList();

            _ds.Dispose();

            return projects;
        }

        public ProjectViewModel GetById(int id)
        {
            var project = _ds
                .GetCollection<Project>("projects")
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id);
            if (project == null) return null;

            var projectViewModel = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Tasks = new List<TasksViewModel>()
            };

            foreach (Models.Task task in project.Tasks)
            {
                var taskViewModel = new TasksViewModel
                {
                    Id = task.Id,
                    Status = task.Status.GetDisplayName(),
                    Priority = task.Priority.GetDisplayName(),
                    TaskType = task.TaskType.GetDisplayName(),
                    CreatedAt = task.CreatedAt.Date.ToString("d"),
                    Assignee = task.Assignee,
                    Description = task.Description,
                    Estimate = task.Estimate,
                    Title = task.Title
                };

                projectViewModel.Tasks.Add(taskViewModel);
            }

            return projectViewModel;
        }
    }
}
