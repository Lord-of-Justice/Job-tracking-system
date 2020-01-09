using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskTrackingSystem.WebApi.Model
{
    /// <summary>
    /// LoginModel
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// LoginModel userName
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// LoginModel password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}