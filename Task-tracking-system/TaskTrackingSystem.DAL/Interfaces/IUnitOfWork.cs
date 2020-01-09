using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DAL.Indentity;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IProjectTaskRepository ProjectTaskRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        Task SaveAsync();
        void SaveChanges();
    }
}
