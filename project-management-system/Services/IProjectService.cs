using project_management_system.Models;

namespace project_management_system.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();
    }
}
