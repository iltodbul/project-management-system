using JsonFlatFileDataStore;
using project_management_system.Models;

namespace project_management_system.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public Project GetById(int id)
        {
            return _ds
                .GetCollection<Project>("projects")
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
