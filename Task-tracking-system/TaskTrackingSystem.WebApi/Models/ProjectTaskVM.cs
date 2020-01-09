using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTrackingSystem.WebApi.Models
{
    /// <summary>
    /// ProjectTaskVM
    /// </summary>
    public class ProjectTaskVM
    {
        /// <summary>
        /// ProjectTaskVM id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ProjectTaskVM name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ProjectTaskVM description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ProjectTaskVM stsatus
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// ProjectTaskVM percentage of execution
        /// </summary>
        public double PercentageOfExecution { get; set; }
        /// <summary>
        /// ProjectTaskVM id of employee who do this task
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// ProjectTaskVM id of manager who set this task
        /// </summary>
        public string IssuedById { get; set; }
        /// <summary>
        /// ProjectTaskVM id of project in which this task is
        /// </summary>
        public int ProjectId { get; set; }
    }
}