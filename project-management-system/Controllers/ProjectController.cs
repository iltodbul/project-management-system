namespace project_management_system.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using project_management_system.Models;
    using project_management_system.Services;
    using project_management_system.ViewModels;

    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IEnumerable<Project> GetAll() => _projectService.GetAllProjects();

        [HttpGet]
        [Route("details/{id:int}")]
        public ProjectViewModel Details(int id) => _projectService.GetById(id);
    }
}
