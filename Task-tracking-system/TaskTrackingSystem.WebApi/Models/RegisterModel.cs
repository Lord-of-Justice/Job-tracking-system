using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskTrackingSystem.WebApi.Models
{
    /// <summary>
    /// RegisterModel
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// RegisterModel user name
        /// </summary>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        /// <summary>
        /// RegisterModel email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// RegisterModel password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// RegisterModel confirm password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// RegisterModel address
        /// </summary>
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// RegisterModel name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}