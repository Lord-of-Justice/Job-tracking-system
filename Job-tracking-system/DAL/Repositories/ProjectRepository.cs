using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Interfaces;
using DAL.DBContext;
using System.Linq;

namespace DAL.Repositories
{
    class ProjectRepository : IRepository<Project>
    {
        private TaskTrackerContext context;
        public ProjectRepository(TaskTrackerContext context)
        {
            this.context = context;
        }
        public void Create(Project project)
        {
            context.Projects.Add(project);
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Projects;
        }

        public Project GetById(int id)
        {
            return context.Projects.Find(id);
        }

        public void Remove(Project project)
        {
            context.Projects.Remove(project);
        }

        public void Update(Project project)
        {
            context.Projects.Update(project);
        }
    }
}
