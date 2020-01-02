using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }  
        public UserInfo UserInfo { get; set; }
    }
}
