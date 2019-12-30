using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Project> ProjectRepository { get; }
        IRepository<Task> TaskRepository { get; }
        IRepository<UserInfo> UserInfoRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IUserRepository UserRepository { get; }
        void SaveChanges();

    }
}
