using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public RoleDTO Role { get; set; }
        public UserDTO User { get; set; }
    }
}
