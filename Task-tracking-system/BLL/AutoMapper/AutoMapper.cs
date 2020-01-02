using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            TwoWayMapping<Project, ProjectDTO>();
            TwoWayMapping<Task, TaskDTO>();
            TwoWayMapping<User, UserDTO>();
            TwoWayMapping<UserInfo, UserInfoDTO>();
            CreateMap<Role, RoleDTO>();
        }
        private  void TwoWayMapping<TFirst, TSecond>()
        {            
            CreateMap<TFirst, TSecond>();
            CreateMap<TFirst, TSecond>().ReverseMap();
        }
    }
}
