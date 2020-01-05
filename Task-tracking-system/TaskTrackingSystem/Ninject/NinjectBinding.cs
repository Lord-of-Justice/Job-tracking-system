using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Modules;
using TaskTrackingSystem.BLL.Services;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.DAL.Interfaces;
using TaskTrackingSystem.DAL.Repositories;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Entities;
using System.Data.Entity;

namespace TaskTrackingSystem.Ninject
{
    public class NinjectBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("DefaultConnection");
            //kernel.Bind<IdentityDbContext, TaskTrackerContext>().To<TaskTrackerContext>();
            Bind<IRepository<Project>>().To<ProjectRepository>();
            Bind<IRepository<ProjectTask>>().To<ProjectTaskRepository>();
            Bind<IUserProfileRepository>().To<UserProfileRepository>();
            Bind<IService<ProjectDTO>>().To<ProjectService>();
            Bind<IService<ProjectTaskDTO>>().To<ProjectTaskService>();
            Bind<IUserInterface>().To<UserService>();
        }
    }
}