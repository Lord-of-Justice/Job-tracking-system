using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public UserInfoDTO UserInfo { get; set; }
    }
}
