using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Interfaces;

namespace TaskTrackingSystem.DAL.Repositories
{
    public class ProjectRepository : IRepository<Project>
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
            context.Entry(project).State = EntityState.Modified;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
