using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Indentity;
using TaskTrackingSystem.DAL.Interfaces;

namespace TaskTrackingSystem.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private TaskTrackerContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IRepository<Project> projectRepository;
        private IRepository<ProjectTask> projectTaskRepository;
        private IUserProfileRepository userProfileRepository;

        public UnitOfWork(string connectionString)
        {
            db = new TaskTrackerContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            projectRepository = new ProjectRepository(db);
            projectTaskRepository = new ProjectTaskRepository(db);
            userProfileRepository = new UserProfileRepository(db);
        }


        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }
        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }
        public IRepository<ProjectTask> ProjectTaskRepository
        {
            get { return projectTaskRepository; }
        }
        public IRepository<Project> ProjectRepository
        {
            get { return projectRepository; }
        }
        public IUserProfileRepository UserProfileRepository
        {
            get { return userProfileRepository; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    projectRepository.Dispose();
                    projectTaskRepository.Dispose();
                    userProfileRepository.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
