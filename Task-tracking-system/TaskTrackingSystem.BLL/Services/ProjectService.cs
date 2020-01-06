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
                cfg.CreateMap<UserProfile, UserDTO>();
                cfg.CreateMap<UserDTO, UserProfile>();

                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<UserDTO, ApplicationUser>();
            });
            _mapper = new Mapper(config);
        }
        public void Create(ProjectDTO item)
        {
            var project = _mapper.Map<Project>(item);
            _db.ProjectRepository.Create(project);
            _db.SaveChanges();
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectDTO>>(_db.ProjectRepository.GetAll());
        }

        public ProjectDTO GetById(int id)
        {
            return _mapper.Map<ProjectDTO>(_db.ProjectRepository.GetById(id));
        }

        public void Remove(ProjectDTO item)
        {
            var project = _db.ProjectRepository.GetById(item.Id);
            project = _mapper.Map(item, project);
            _db.ProjectRepository.Remove(project);
            _db.SaveChanges();
        }

        public void Update(ProjectDTO item)
        {
            var project = _db.ProjectRepository.GetById(item.Id);
            project = _mapper.Map(item, project);
            _db.ProjectRepository.Update(project);
            _db.SaveChanges();
        }
    }
}
