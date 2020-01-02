using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.DBContext
{
    public class TaskTrackerContext : DbContext, ITaskTrackerContext
    {
        public TaskTrackerContext() { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS01;Initial Catalog = TaskTrackingSystem; Integrated Security = True;");
        }*/
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) 
            :base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
    }

    public class EntitiesContextInitializer
    {
        void InitializeRole(TaskTrackerContext context)
        {
            List<Role> roles = new List<Role>
            {
                new Role { Name = "Admin"},
                new Role { Name = "Client"},
                new Role { Name = "Employee"},
                new Role { Name = "Manager"}
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
        private Role GetRole(string name, TaskTrackerContext context)
        {
            return context.Roles.Find(name);
        }
        void InitializeUsers(TaskTrackerContext context)
        {
            List<UserInfo> userInfos = new List<UserInfo>
            {
                new UserInfo { Name = "Ivan", Email = "Admin_Email@gmail.com", Role = GetRole("Admin", context)},
                new UserInfo { Name = "Dima", Email = "manager_Email@gmail.com", Role = GetRole("Manager", context)},
                new UserInfo { Name = "Artem", Email = "client1_Email@gmail.com", Role = GetRole("Employee", context)},
                new UserInfo { Name = "Petro", Email = "client2_Email@gmail.com", Role = GetRole("Employee", context)},
                new UserInfo { Name = "Danya", Email = "client3_Email@gmail.com", Role = GetRole("Client", context)}
            };
            List<User> users = new List<User>
            {
                new User {LoginName = "admin", PasswordHash = "admin", UserInfo = userInfos[0]},
                new User {LoginName = "manager", PasswordHash = "manager", UserInfo = userInfos[1]},
                new User {LoginName = "Lors_Artem", PasswordHash = "qwerty", UserInfo = userInfos[2]},
                new User {LoginName = "Petro123", PasswordHash = "123petro321", UserInfo = userInfos[3]},
                new User {LoginName = "Danyaaaa", PasswordHash = "lolqwerty", UserInfo = userInfos[4]}
            };
            int counter = 0;
            foreach (UserInfo inf in userInfos){
                inf.User = users[counter];
                counter++;
            }

            context.Users.AddRange(users);
            context.UserInfos.AddRange(userInfos);
            context.SaveChanges();
        }
        private User GetUser(int id, TaskTrackerContext context)
        {
            return context.Users.Find(id);
        }
        void InitializeProjects(TaskTrackerContext context)
        {
            List<Task> tasks = new List<Task>
            {
                new Task { Name = "WEB Api system", Description = "Develop WEB Api system", Status = "Ice Box",
                    PercentageOfExecution = 0, Employee = null, IssuedBy = null},
                new Task { Name = "Unit Tests", Description = "Developing unit tests", Status = "In progress",
                    PercentageOfExecution = 40, Employee = GetUser(3, context), IssuedBy = GetUser(1, context)},
                new Task { Name = "Business Logic Layer", Description = "Developing BLL", Status = "Testing",
                    PercentageOfExecution = 75,  Employee = GetUser(2, context), IssuedBy = GetUser(1, context)},
                new Task { Name = "Data Access Layer", Description = "Developing Data Access Layer", Status = "Complete",
                    PercentageOfExecution = 100,  Employee = GetUser(3, context), IssuedBy = GetUser(1, context)}
            };
            Project project = new Project{ Name = "Task Tracking System", Status = "In progress", Client = GetUser(4, context),
                DataStart = DateTime.Now, DataEnd = DateTime.Now.AddDays(20), Tasks = tasks};
            foreach (Task task in tasks)
            {
                task.Project = project;
            }

            context.Tasks.AddRange(tasks);
            context.Projects.Add(project);
            context.SaveChanges();
        }

        public void Seed(TaskTrackerContext context)
        {
            InitializeRole(context);
            InitializeUsers(context);
            InitializeProjects(context);
        }
    }
}
