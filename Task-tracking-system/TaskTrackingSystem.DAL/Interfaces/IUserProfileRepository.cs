using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.Interfaces
{
    public interface IUserProfileRepository : IDisposable
    {
        void Create(UserProfile user);
        UserProfile GetById(string id);
        IEnumerable<UserProfile> GetAll();
        void Remove(UserProfile user);
        void Update(UserProfile user);
    }
}
