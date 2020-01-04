using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.EF
{
    class TaskTrackerContext : IdentityDbContext<ApplicationUser>
    {
        public TaskTrackerContext() : base("TaskTrackerContext", throwIfV1Schema: false) { }
        public TaskTrackerContext(string connectionString) : base(connectionString) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        public static TaskTrackerContext Create()
        {
            return new TaskTrackerContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}

