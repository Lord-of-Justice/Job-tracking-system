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
    class UserInfoService : IService<UserInfoDTO>
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public UserInfoService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void Create(UserInfoDTO item)
        {
            var project = _mapper.Map<UserInfo>(item);
            _db.UserInfoRepository.Create(project);
            _db.SaveChanges();
        }

        public IEnumerable<UserInfoDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserInfoDTO>>(_db.UserInfoRepository.GetAll());
        }

        public UserInfoDTO GetById(int id)
        {
            return _mapper.Map<UserInfoDTO>(_db.UserInfoRepository.GetById(id));
        }

        public void Remove(UserInfoDTO item)
        {
            var project = _mapper.Map<UserInfo>(item);
            _db.UserInfoRepository.Remove(project);
            _db.SaveChanges();
        }

        public void Update(UserInfoDTO item)
        {
            var project = _mapper.Map<UserInfo>(item);
            _db.UserInfoRepository.Update(project);
            _db.SaveChanges();
        }
    }
}
