using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Interfaces;
using DAL.DBContext;

namespace DAL.Repositories
{
    class UserRepository : IUserRepository
    {
        private TaskTrackerContext context;
        public UserRepository(TaskTrackerContext context)
        {
            this.context = context;
        }

        public void Create(User user)
        {
            context.Users.Add(user);
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Remove(User user)
        {
            context.Users.Remove(user);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }
    }
}
