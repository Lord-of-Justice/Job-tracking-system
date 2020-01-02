using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public UserDTO Client { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public ICollection<TaskDTO> Tasks { get; set; }
    }
}
