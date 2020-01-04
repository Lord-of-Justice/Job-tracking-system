using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.DAL.Interfaces;
using TaskTrackingSystem.DAL.Entities;
using AutoMapper;


namespace TaskTrackingSystem.BLL.Services
{
    class ProjectTaskService : IService<ProjectTaskDTO>
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public ProjectTaskService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async void Create(ProjectTaskDTO item)
        {
            var project = _mapper.Map<ProjectTask>(item);
            _db.ProjectTaskRepository.Create(project);
            await _db.SaveAsync();
        }

        public IEnumerable<ProjectTaskDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectTaskDTO>>(_db.ProjectTaskRepository.GetAll());
        }

        public ProjectTaskDTO GetById(int id)
        {
            return _mapper.Map<ProjectTaskDTO>(_db.ProjectTaskRepository.GetById(id));
        }

        public async void Remove(ProjectTaskDTO item)
        {
            var project = _mapper.Map<ProjectTask>(item);
            _db.ProjectTaskRepository.Remove(project);
            await _db.SaveAsync();
        }

        public async void Update(ProjectTaskDTO item)
        {
            var project = _mapper.Map<ProjectTask>(item);
            _db.ProjectTaskRepository.Update(project);
            await _db.SaveAsync();
        }
    }
}
