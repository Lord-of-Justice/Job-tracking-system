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
    public class ProjectTaskRepository : IRepository<ProjectTask>
    {
        private TaskTrackerContext context;
        public ProjectTaskRepository(TaskTrackerContext context)
        {
            this.context = context;
        }
        public void Create(ProjectTask projectTask)
        {
            context.ProjectTasks.Add(projectTask);
        }

        public IEnumerable<ProjectTask> GetAll()
        {
            return context.ProjectTasks;
        }

        public ProjectTask GetById(int id)
        {
            return context.ProjectTasks.Find(id);
        }

        public void Remove(ProjectTask projectTask)
        {
            context.ProjectTasks.Remove(projectTask);
        }

        public void Update(ProjectTask projectTask)
        {
            context.Entry(projectTask).State = EntityState.Modified;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}

