using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.BLL.AutoMapper
{
    class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            TwoWayMapping<Project, ProjectDTO>();
            TwoWayMapping<Task, ProjectTaskDTO>();
            //CreateMap<Role, RoleDTO>();
        }
        private void TwoWayMapping<TFirst, TSecond>()
        {
            CreateMap<TFirst, TSecond>();
            CreateMap<TFirst, TSecond>().ReverseMap();
        }
    }
}
