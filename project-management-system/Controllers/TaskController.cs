namespace project_management_system.Controllers
{
    using JsonFlatFileDataStore;

    using Microsoft.AspNetCore.Mvc;

    using project_management_system.Models;
    using project_management_system.Services;
    using project_management_system.ViewModels;


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

        [HttpPut]
        public IActionResult Edit(TaskInputViewModel model)
        {
            return Ok();
        }
    }
}
