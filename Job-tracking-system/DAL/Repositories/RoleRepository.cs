using System;
using System.Collections.Generic;
using System.Text;
using DAL.DBContext;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class RoleRepository : IRepository<Role>
    {
        private TaskTrackerContext context;
        public RoleRepository(TaskTrackerContext context)
        {
            this.context = context;
        }

        public void Create(Role role)
        {
            context.Roles.Add(role);
        }

        public Role GetById(int id)
        {
            return context.Roles.Find(id);
        }
        public IEnumerable<Role> GetAll()
        {
            return context.Roles;
        }

        public void Remove(Role role)
        {
            context.Roles.Remove(role);
        }

        public void Update(Role role)
        {
            context.Roles.Update(role);
        }
    }
}
