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
    public class UserProfileRepository : IUserProfileRepository
    {
        private TaskTrackerContext context;
        public UserProfileRepository(TaskTrackerContext context)
        {
            this.context = context;
        }
        public void Create(UserProfile userInfo)
        {
            context.UserProfile.Add(userInfo);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return context.UserProfile;
        }

        public UserProfile GetById(string id)
        {
            return context.UserProfile.Find(id); 
        }

        public void Remove(UserProfile userInfo)
        {
            context.UserProfile.Remove(userInfo);
            context.SaveChanges();
        }

        public void Update(UserProfile userInfo)
        {
            context.Entry(userInfo).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
