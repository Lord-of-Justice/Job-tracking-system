using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTrackingSystem.WebApi.Models
{
    /// <summary>
    /// UserVM
    /// </summary>
    public class UserVM
    {
        /// <summary>
        /// User id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// User role
        /// </summary>
        public string Role { get; set; }
    }
}