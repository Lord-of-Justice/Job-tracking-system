using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTO;

namespace TaskTrackingSystem.BLL.Interfaces
{
    public interface IProjectService
    {
        void Create(ProjectDTO item);
        ProjectDTO GetById(int id);
        IEnumerable<ProjectDTO> GetAll();
        void Remove(ProjectDTO item);
        void Update(ProjectDTO item);
        IEnumerable<ProjectTaskDTO> GetTasksByProjectId(int projectId);
    }
}
