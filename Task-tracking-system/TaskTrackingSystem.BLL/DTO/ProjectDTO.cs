using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskTrackingSystem.BLL.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public UserDTO Client { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public ICollection<ProjectTaskDTO> Tasks { get; set; }
    }
}
