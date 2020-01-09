using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTO;

namespace TaskTrackingSystem.BLL.Interfaces
{
    public interface IProjectTaskService
    {
        void Create(ProjectTaskDTO item);
        ProjectTaskDTO GetById(int id);
        IEnumerable<ProjectTaskDTO> GetAll();
        void Remove(ProjectTaskDTO item);
        void Update(ProjectTaskDTO item);
    }
}
