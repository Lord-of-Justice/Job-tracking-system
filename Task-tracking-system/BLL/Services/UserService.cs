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
    class UserService : IUserService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void Create(UserDTO item)
        {
            var project = _mapper.Map<User>(item);
            _db.UserRepository.Create(project);
            _db.SaveChanges();
        }

        public UserDTO GetUserById(int id)
        {
            return _mapper.Map<UserDTO>(_db.UserRepository.GetById(id));
        }

        public void Remove(UserDTO item)
        {
            var project = _mapper.Map<User>(item);
            _db.UserRepository.Remove(project);
            _db.SaveChanges();
        }

        public void Update(UserDTO item)
        {
            var project = _mapper.Map<User>(item);
            _db.UserRepository.Update(project);
            _db.SaveChanges();
        }
    }
}
