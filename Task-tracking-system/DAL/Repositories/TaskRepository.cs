using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Interfaces;
using DAL.DBContext;

namespace DAL.Repositories
{
    class TaskRepository : IRepository<Task>
    {
        private TaskTrackerContext context;
        public TaskRepository(TaskTrackerContext context)
        {
            this.context = context;
        }
        public void Create(Task task)
        {
            context.Tasks.Add(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return context.Tasks;
        }

        public Task GetById(int id)
        {
            return context.Tasks.Find(id);
        }

        public void Remove(Task task)
        {
            context.Tasks.Remove(task);
        }

        public void Update(Task task)
        {
            context.Tasks.Update(task);
        }
    }
}
