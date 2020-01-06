using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTrackingSystem.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ProjectTask> Tasks { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
