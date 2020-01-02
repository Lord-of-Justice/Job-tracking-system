using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Entities;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private TaskTrackerContext context;
        private ProjectRepository projectRepository; 
        private TaskRepository taskRepository;
        private RoleRepository roleRepository;
        private UserInfoRepository userInfoRepository;
        private UserRepository userRepository;
        public UnitOfWork(TaskTrackerContext context)
        {
            this.context = context;
        }

        public IRepository<Project> ProjectRepository
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(context);
                return projectRepository;
            }
        }
        public IRepository<Task> TaskRepository
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(context);
                return taskRepository;
            }
        }
        public IRepository<UserInfo> UserInfoRepository
        {
            get
            {
                if (userInfoRepository == null)
                    userInfoRepository = new UserInfoRepository(context);
                return userInfoRepository;
            }
        }
        public IRepository<Role> RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(context);
                return roleRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
