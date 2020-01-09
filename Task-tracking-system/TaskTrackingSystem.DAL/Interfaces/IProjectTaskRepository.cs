using System;
using System.Collections.Generic;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.Interfaces
{
    public interface IProjectTaskRepository : IDisposable 
    {
        void Create(ProjectTask item);
        ProjectTask GetById(int id);
        IEnumerable<ProjectTask> GetAll();
        void Remove(ProjectTask item);
        void Update(ProjectTask item);
        IEnumerable<ProjectTask> GetByProjectId(int ProjectId);
        IEnumerable<ProjectTask> GetByEmployeeId(string employeeId);
    }
}
