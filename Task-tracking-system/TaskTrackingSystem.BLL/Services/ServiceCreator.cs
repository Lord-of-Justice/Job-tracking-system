using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.DAL.Repositories;

namespace TaskTrackingSystem.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserInterface CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }
    }
}
