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
    public class ProjectService : IService<ProjectDTO>
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public ProjectService(IUnitOfWork db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProjectDTO, Project>();
                cfg.CreateMap<Project, ProjectDTO>();
            });
            _mapper = new Mapper(config);
        }
        public async void Create(ProjectDTO item)
        {
            var project = _mapper.Map<Project>(item);
            _db.ProjectRepository.Create(project);
            await _db.SaveAsync();
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectDTO>>(_db.ProjectRepository.GetAll());
        }

        public ProjectDTO GetById(int id)
        {
            return _mapper.Map<ProjectDTO>(_db.ProjectRepository.GetById(id));
        }

        public async void Remove(ProjectDTO item)
        {
            var project = _mapper.Map<Project>(item);
            _db.ProjectRepository.Remove(project);
            await _db.SaveAsync();
        }

        public async void Update(ProjectDTO item)
        {
            var project = _mapper.Map<Project>(item);
            _db.ProjectRepository.Update(project);
            await _db.SaveAsync();
        }
    }
}
