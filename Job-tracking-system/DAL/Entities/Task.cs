using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public double PercentageOfExecution { get; set; }

        public int? EmployeeId { get; set; }
        public User Employee { get; set; }
        [Column("IssuedById")]
        public int? IssuedById { get; set; }
        public User IssuedBy { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
