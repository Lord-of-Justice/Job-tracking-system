using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public int ClientId { get; set; }
        public User Client { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
