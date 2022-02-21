namespace project_management_system.Services
{
    using System.Collections.Generic;

    using project_management_system.Models;
    using project_management_system.ViewModels;

    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();

        ProjectViewModel GetById(int id);
    }
}
