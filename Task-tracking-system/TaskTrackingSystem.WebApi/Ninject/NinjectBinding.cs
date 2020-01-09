using Ninject.Modules;
using TaskTrackingSystem.BLL.Services;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.DAL.Interfaces;
using TaskTrackingSystem.DAL.Repositories;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.WebApi.Ninject
{
    /// <summary>
    /// 
    /// </summary>
    public class NinjectBinding : NinjectModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("DefaultConnection");
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IProjectTaskRepository>().To<ProjectTaskRepository>();
            Bind<IUserProfileRepository>().To<UserProfileRepository>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectTaskService>().To<ProjectTaskService>();
            Bind<IUserInterface>().To<UserService>();
        }
    }
}