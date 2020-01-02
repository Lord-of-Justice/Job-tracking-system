using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Role
    {
        [Key]
        public string Name { get; set; }
        public ICollection<UserInfo> Users { get; set; }
    }
}
