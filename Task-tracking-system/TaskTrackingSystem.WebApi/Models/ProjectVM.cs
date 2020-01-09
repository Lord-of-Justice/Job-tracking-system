using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTrackingSystem.WebApi.Models
{
    /// <summary>
    /// ProjectVM
    /// </summary>
    public class ProjectVM
    {
        /// <summary>
        /// ProjectVM id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ProjectVM name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ProjectVM stsatus
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// ProjectVM id of client who needed this project
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// ProjectVM date start of project
        /// </summary>
        public DateTime DataStart { get; set; }
        /// <summary>
        /// ProjectVM date end of project
        /// </summary>
        public DateTime DataEnd { get; set; }
    }
}