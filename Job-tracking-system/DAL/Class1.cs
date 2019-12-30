using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;
using DAL.Entities;
using DAL.DBContext;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    class Class1
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
                init.Seed(db);
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.LoginName} - {u.PasswordHash}");
                }
            }
            Console.Read();
        }
    }
}
