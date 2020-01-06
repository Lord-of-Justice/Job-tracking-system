using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.BLL.DTO
{
    public class ProjectTaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public double PercentageOfExecution { get; set; }

        public string EmployeeId { get; set; }
        public UserDTO Employee { get; set; }
        public string IssuedById { get; set; }
        public UserDTO IssuedBy { get; set; }
        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
