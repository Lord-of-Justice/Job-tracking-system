using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services
{
    class ProjectService : IService<ProjectDTO>
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public ProjectService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
            var project = _mapper.Map<Project>(item);
            _db.ProjectRepository.Remove(project);
            _db.SaveChanges();
        }

        public void Update(ProjectDTO item)
        {
            var project = _mapper.Map<Project>(item);
            _db.ProjectRepository.Update(project);
            _db.SaveChanges();
        }
    }
}
