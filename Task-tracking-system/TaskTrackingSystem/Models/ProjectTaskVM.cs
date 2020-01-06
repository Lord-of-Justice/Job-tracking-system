using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTrackingSystem.Models
{
    public class ProjectTaskVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public double PercentageOfExecution { get; set; }

        public string EmployeeId { get; set; }
        public string IssuedById { get; set; }
        public int ProjectId { get; set; }
    }
}