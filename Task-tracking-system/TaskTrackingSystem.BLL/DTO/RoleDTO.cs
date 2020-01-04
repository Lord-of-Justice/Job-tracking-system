using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.BLL.DTO
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
