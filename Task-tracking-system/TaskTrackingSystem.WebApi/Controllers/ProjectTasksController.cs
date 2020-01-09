using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.WebApi.Models;
using System.Web.Http.Description;

namespace TaskTrackingSystem.WebApi.Controllers
{
    /// <summary>
    /// ProjectTask api
    /// </summary>
    [RoutePrefix("api")]
    [Authorize(Roles = "admin, manager, employee")]
    public class ProjectTasksController : ApiController
    {
        private IProjectTaskService _projectTaskService;
        private IMapper _mapper;
        /// <summary>
        /// ProjectTask Controller constructor
        /// </summary>
        /// <param name="service">Service for crud ProjectTasks</param>
        public ProjectTasksController(IProjectTaskService service)
        {
            _projectTaskService = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectTaskVM, ProjectTaskDTO>();
                cfg.CreateMap<ProjectTaskDTO, ProjectTaskVM>();
            });
            _mapper = new Mapper(config);
        }
        /// <summary>
        /// Get all ProjectTasks
        /// </summary>
        /// <remarks>
        /// Get a list of all ProjectTasks
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response> 
        [ResponseType(typeof(IEnumerable<ProjectTaskVM>))]
        [HttpGet]
        [Route("projecttask")]
        // GET: api/projecttask
        public IEnumerable<ProjectTaskVM> Get()
        {
            return _mapper.Map<IEnumerable<ProjectTaskVM>>(_projectTaskService.GetAll());
        }

        /// <summary>
        /// Get ProjectTask by id
        /// </summary>
        /// <remarks>
        /// Get a ProjectTask by id
        /// </remarks>
        /// <param name="id">Id of ProjectTask</param>
        /// <returns></returns>
        /// <response code="200">ProjectTask found</response>
        ///<response code = "404" > ProjectTask not foundd</response>
        [ResponseType(typeof(ProjectTaskVM))]
        [HttpGet]
        [Route("projecttask/{id}", Name = "GetProjectTask")]
        // GET: api/projecttask/5
        public IHttpActionResult Get(int id)
        {
            var projectTaskVM = _mapper.Map<ProjectTaskVM>(_projectTaskService.GetById(id));
            if (projectTaskVM == null)
            {
                return NotFound();
            }
            return Ok(projectTaskVM);
        }

        /// <summary>
        /// Create a ProjectTask
        /// </summary>
        /// <remarks>
        /// Create a new ProjectTask
        /// </remarks>
        /// <param name="projectTaskVM">ProjectTask for creation</param>
        /// <returns></returns>
        /// <response code="200">ProjectTask created</response>
        /// <response code="400">Bad request</response>
        [ResponseType(typeof(ProjectTaskVM))]
        [HttpPost]
        [Route("projecttask/new")]
        // POST: api/projecttask/new
        public IHttpActionResult Post([FromBody] ProjectTaskVM projectTaskVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projectTaskDTO = _mapper.Map<ProjectTaskDTO>(projectTaskVM);
            _projectTaskService.Create(projectTaskDTO);
            return CreatedAtRoute("GetProjectTask", new { id = projectTaskVM.Id }, projectTaskVM);
        }

        /// <summary>
        /// Update an existing ProjectTask
        /// </summary>
        /// <param name="projectTaskVM">ProjectTask to update</param>
        /// <returns></returns>
        /// <response code="200">ProjectTask updated</response>
        /// <response code="404">ProjectTask not found</response>

        [ResponseType(typeof(ProjectTaskVM))]
        [HttpPost]
        [Route("projecttask/update")]
        // PUT api/projecttask/update
        public IHttpActionResult Put([FromBody]ProjectTaskVM projectTaskVM)
        {
            var sourceProject = _projectTaskService.GetById(projectTaskVM.Id);
            if (sourceProject == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projectTaskDTO = _mapper.Map<ProjectTaskDTO>(projectTaskVM);
            _projectTaskService.Update(projectTaskDTO);
            return CreatedAtRoute("GetProjectTask", new { id = projectTaskVM.Id }, projectTaskVM);
        }

        /// <summary>
        /// Delete a ProjectTask
        /// </summary>
        /// <remarks>
        /// Delete a ProjectTask
        /// </remarks>
        /// <param name="projectTaskVM">ProjectTask to delete</param>
        /// <returns></returns>
        /// <response code="200">ProjectTask deleted</response>
        /// <response code="404">ProjectTask not found</response>
        [HttpPost]
        [Route("projecttask/delete")]
        // DELETE api/projecttask/delete
        public IHttpActionResult Delete([FromBody]ProjectTaskVM projectTaskVM)
        {
            var sourceProject = _projectTaskService.GetById(projectTaskVM.Id);
            if (sourceProject == null)
            {
                return NotFound();
            }
            _projectTaskService.Remove(sourceProject);
            return Ok();
        }
    }
}