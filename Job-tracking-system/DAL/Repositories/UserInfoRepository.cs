using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Interfaces;
using DAL.DBContext;

namespace DAL.Repositories
{
    class UserInfoRepository : IRepository<UserInfo>
    {
        private TaskTrackerContext context;
        public UserInfoRepository(TaskTrackerContext context)
        {
            this.context = context;
        }
        public void Create(UserInfo userInfo)
        {
            context.UserInfos.Add(userInfo);
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return context.UserInfos;
        }

        public UserInfo GetById(int id)
        {
            return context.UserInfos.Find(id);
        }

        public void Remove(UserInfo userInfo)
        {
            context.UserInfos.Remove(userInfo);
        }

        public void Update(UserInfo userInfo)
        {
            context.UserInfos.Update(userInfo);
        }
    }
}
