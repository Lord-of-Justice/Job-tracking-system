using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTrackingSystem.WebApi.Models
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string ClientId { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public ICollection<ProjectTaskVM> Tasks { get; set; }
    }
}