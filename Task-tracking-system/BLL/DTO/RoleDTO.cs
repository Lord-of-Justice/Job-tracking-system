using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public ICollection<UserInfoDTO> Users { get; set; }
    }
}
