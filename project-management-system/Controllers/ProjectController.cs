using System.IO;
using System.Text;
using JsonFlatFileDataStore;
using project_management_system.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project_management_system.Services;

namespace project_management_system.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IDataStore _ds;

        public ProjectController(IProjectService projectService, IDataStore ds)
        {
            _projectService = projectService;
            _ds = ds;
        }

        [HttpGet]
        public IEnumerable<Project> GetAll() => _projectService.GetAllProjects();

        [HttpGet]
        [Route("details")]
        public Project Details(int id)
        {
            return _projectService.GetById(id);
        }


        [HttpHead]
        public async Task<ActionResult<object>> Get()
        {
            //var newProject = new Project
            //{
            //    Id = 3,
            //    Name = "Third project",
            //    Tasks = new List<Models.Task>()
            //};

            var toManipulateProject = _ds.GetCollection<Project>("projects");

            //var prId2 = projects.Find(x=>x.id == 2);

            //var prId1 = projects1.Find(x => x.Id == 1);

            //await toManipulateProject.InsertOneAsync(newProject);

            var prj = _ds.GetCollection<Project>("projects");
            var pr3 = prj.AsQueryable().FirstOrDefault(x => x.Id == 3);
            pr3.Name = "Third project";
            await prj.UpdateOneAsync(pr3.Id, pr3);

            var toListProjects = _ds.GetCollection<Project>("projects").AsQueryable().ToList();

            _ds.Dispose();

            return toListProjects;

        }
    }
}
