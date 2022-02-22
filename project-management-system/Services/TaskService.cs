namespace project_management_system.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JsonFlatFileDataStore;

    using project_management_system.Models.Enums;
    using project_management_system.Extensions;
    using project_management_system.Models;
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
            var task = GetTaskById(id);

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

        public bool Edit(TaskInputViewModel model)
        {
            var taskId = model.Id;

            var allTasks = GetAllTasks();

            var newTask = new Models.Task()
            {
                Id = model.Id,
                Status = (Status)model.Status,
                Priority = (Priority)model.Priority,
                TaskType = (TaskType)model.TaskType,
                CreatedAt = DateTime.Parse(model.CreatedAt),
                Assignee = model.Assignee,
                Description = model.Description,
                Estimate = model.Estimate,
                Title = model.Title
            };

            return true;
        }

        private Task GetTaskById(int id)
        {
            var tasks = GetAllTasks();

            var task = tasks.Find(x => x.Id == id);

            return task ?? null;
        }

        private List<Task> GetAllTasks()
        {
            var allProjects = _ds.GetCollection<Project>("projects").AsQueryable().ToList();

            var tasks = allProjects.SelectMany(project => project.Tasks).ToList();

            return tasks;
        }
    }
}
