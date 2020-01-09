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
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public ProjectTaskService(IUnitOfWork db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg => { 
                cfg.CreateMap<ProjectTaskDTO, ProjectTask>();
                cfg.CreateMap<ProjectTask, ProjectTaskDTO>();
            }) ;
            _mapper = new Mapper(config);
        }
        public void Create(ProjectTaskDTO item)
        {
            var project = _mapper.Map<ProjectTask>(item);
            _db.ProjectTaskRepository.Create(project);
            _db.SaveChanges();
        }

        public IEnumerable<ProjectTaskDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectTaskDTO>>(_db.ProjectTaskRepository.GetAll());
        }

        public ProjectTaskDTO GetById(int id)
        {
            return _mapper.Map<ProjectTaskDTO>(_db.ProjectTaskRepository.GetById(id));
        }

        public void Remove(ProjectTaskDTO item)
        {
            var project = _db.ProjectTaskRepository.GetById(item.Id);
            project = _mapper.Map(item, project);
            _db.ProjectTaskRepository.Remove(project);
            _db.SaveChanges();
        }

        public void Update(ProjectTaskDTO item)
        {
            var project = _db.ProjectTaskRepository.GetById(item.Id);
            project = _mapper.Map(item, project);
            _db.ProjectTaskRepository.Update(project);
            _db.SaveChanges();
        }
    }
}
