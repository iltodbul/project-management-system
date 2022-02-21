using System.Collections.Generic;
using System.Linq;
using JsonFlatFileDataStore;
using project_management_system.Extensions;
using project_management_system.Models;

namespace project_management_system.Services
{
    using project_management_system.ViewModels;

    public class TaskService : ITaskService
    {
        private readonly IDataStore _ds;

        public TaskService(IDataStore ds)
        {
            _ds = ds;
        }

        public TasksViewModel GetById(int id)
        {
            var allProjects = _ds.GetCollection<Project>("projects").AsQueryable().ToList();

            var tasks = new List<Models.Task>();
            foreach (Project project in allProjects)
            {
                foreach (Models.Task t in project.Tasks)
                {
                    tasks.Add(t);
                }
            }

            var task = tasks.Find(x => x.Id == id);

            if (task == null) return null;

            var taskViewModel = new TasksViewModel()
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

            return taskViewModel;
        }
    }
}
