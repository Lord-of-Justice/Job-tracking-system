using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.Interfaces
{
    public interface IProjectRepository : IDisposable
    {
        void Create(Project item);
        Project GetById(int id);
        IEnumerable<Project> GetAll();
        void Remove(Project item);
        void Update(Project item);
    }
}
