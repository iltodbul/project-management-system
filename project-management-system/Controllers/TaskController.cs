using project_management_system.Services;
using project_management_system.ViewModels;

namespace project_management_system.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JsonFlatFileDataStore;

    using Microsoft.AspNetCore.Mvc;

    using project_management_system.Models;


    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IDataStore _ds;

        public TaskController(ITaskService taskService ,IDataStore ds)
        {
            _taskService = taskService;
            _ds = ds;
        }

        [HttpGet]
        [Route("details/{id:int}")]
        public TasksViewModel Details(int id) => _taskService.GetById(id);

        [HttpGet]
        public ActionResult<object> Get()
        {
            //var newProject = new Project
            //{
            //    Id = 3,
            //    Name = "Third project",
            //    Tasks = new List<Models.Task>()
            //};

            //var toManipulateProject = _ds.GetCollection<Project>("projects");

            //var prId2 = projects.Find(x=>x.id == 2);

            //var prId1 = projects1.Find(x => x.Id == 1);

            //await toManipulateProject.InsertOneAsync(newProject);

            //var prj = _ds.GetCollection<Project>("projects");
            //var pr3 = prj.AsQueryable().FirstOrDefault(x => x.Id == 3);
            //pr3.Name = "Third project";
            //await prj.UpdateOneAsync(pr3.Id, pr3);

            //var all = _ds.GetCollection("projects");

            
            //var project = allProjects.Find(x => x.Id == projectId);

            //var task = project.Tasks.FirstOrDefault(x => x.Id == taskId);

            //_ds.Dispose();

            return null;

        }
    }
}
