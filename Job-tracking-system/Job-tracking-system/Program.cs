using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using System.IO;
using DAL.Entities;
using DAL.DBContext;
using System.Diagnostics;

namespace Job_tracking_system
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<TaskTrackerContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (TaskTrackerContext db = new TaskTrackerContext(options))
            {
                EntitiesContextInitializer init = new EntitiesContextInitializer();
                // for first creation in database
                //init.Seed(db);
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Debug.WriteLine($"{u.Id}.{u.LoginName} - {u.PasswordHash}");
                }
            }


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
