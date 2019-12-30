using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ITaskTrackerContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserInfo> UserInfos { get; set; }
    }
}
