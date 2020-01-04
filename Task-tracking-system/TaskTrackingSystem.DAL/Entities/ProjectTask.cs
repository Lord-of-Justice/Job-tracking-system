using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTrackingSystem.DAL.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public double PercentageOfExecution { get; set; }

        public int? EmployeeId { get; set; }
        public UserProfile Employee { get; set; }
        [Column("IssuedById")]
        public int? IssuedById { get; set; }
        public UserProfile IssuedBy { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
