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
    class TaskService : IService<TaskDTO>
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public TaskService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void Create(TaskDTO item)
        {
            var project = _mapper.Map<Task>(item);
            _db.TaskRepository.Create(project);
            _db.SaveChanges();
        }

        public IEnumerable<TaskDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<TaskDTO>>(_db.TaskRepository.GetAll());
        }

        public TaskDTO GetById(int id)
        {
            return _mapper.Map<TaskDTO>(_db.TaskRepository.GetById(id));
        }

        public void Remove(TaskDTO item)
        {
            var project = _mapper.Map<Task>(item);
            _db.TaskRepository.Remove(project);
            _db.SaveChanges();
        }

        public void Update(TaskDTO item)
        {
            var project = _mapper.Map<Task>(item);
            _db.TaskRepository.Update(project);
            _db.SaveChanges();
        }
    }
}
