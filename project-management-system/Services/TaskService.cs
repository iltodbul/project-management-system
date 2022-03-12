using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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
        private readonly IWebHostEnvironment _environment;

        public TaskService(IDataStore ds, IWebHostEnvironment environment)
        {
            _ds = ds;
            _environment = environment;
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
            var filePath = _environment.WebRootPath + @"\dataStore\datastore.json";
            string result = string.Empty;

            using (StreamReader r = new StreamReader(filePath))
            {
                var json = r.ReadToEnd();

                var jObject = JObject.Parse(json);
                JArray jArray = (JArray)jObject["projects"];
                IList<Project> projects = jArray.ToObject<IList<Project>>();

                EditTask(projects, model);

                var newJArray = new JArray();
                foreach (Project project in projects)
                {
                    newJArray.Add(JObject.FromObject(project));
                }
                var newJObject = new JObject();
                newJObject["projects"] = newJArray;

                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
                result = JsonConvert.SerializeObject(newJObject, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });
            }
            File.WriteAllText(filePath, result);

            return true;
        }

        private void EditTask(IList<Project> projects, TaskInputViewModel model)
        {
            Models.Task taskToChange = projects.SelectMany(x => x.Tasks).FirstOrDefault(t => t.Id == model.Id);

            var newTask = new Models.Task()
            {
                Id = model.Id,
                Status = Enum.Parse<Status>(model.Status),
                Priority = Enum.Parse<Priority>(model.Priority),
                TaskType = Enum.Parse<TaskType>(model.TaskType),
                CreatedAt = DateTime.Parse(model.CreatedAt),
                Assignee = model.Assignee,
                Description = model.Description,
                Estimate = model.Estimate,
                Title = model.Title
            };

            var newProjects = new List<Project>();

            for (int i = 0; i < projects.Count; i++)
            {
                var project = projects[i];
                if (project.Tasks.Contains(taskToChange))
                {
                    var tasks = project.Tasks.ToList();
                    tasks.Replace<Models.Task>(taskToChange, newTask);
                    project.Tasks = tasks;
                    newProjects.Add(project);
                }
                else
                {
                    newProjects.Add(project);
                }
            }
        }

        private Task GetTaskById(int id)
        {
            var tasks = GetAllTasks();

            var task = tasks.Find(x => x.Id == id);

            return task ?? null;
        }

        private List<Models.Task> GetAllTasks()
        {
            var allProjects = _ds.GetCollection<Project>("projects").AsQueryable().ToList();

            var tasks = allProjects.SelectMany(project => project.Tasks).ToList();

            return tasks;
        }
    }
}
