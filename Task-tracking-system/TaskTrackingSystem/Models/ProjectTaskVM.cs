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

        public UserVM Employee { get; set; }
        public UserVM IssuedBy { get; set; }
        public ProjectVM Project { get; set; }
    }
}