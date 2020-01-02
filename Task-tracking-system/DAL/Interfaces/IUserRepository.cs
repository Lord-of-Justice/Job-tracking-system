using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        User GetById(int id);
        void Remove(User user);
        void Update(User user);
    }
}
