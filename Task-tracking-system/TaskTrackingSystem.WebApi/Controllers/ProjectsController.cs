using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Http;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.WebApi.Models;
using AutoMapper;
using System.Web.Http.Description;

namespace TaskTrackingSystem.Controllers
{
    /// <summary>
    /// Project api
    /// </summary>
    [RoutePrefix("api")]
    [Authorize]
    public class ProjectsController : ApiController
    {
        private IProjectService _projectService;
        private IMapper _mapper;
        /// <summary>
        /// Projects Controller constructor
        /// </summary>
        /// <param name="service">Service for crud projects</param>
        public ProjectsController(IProjectService service)
        {
            _projectService = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectVM, ProjectDTO>();
                cfg.CreateMap<ProjectDTO, ProjectVM>();
                cfg.CreateMap<ProjectTaskVM, ProjectTaskDTO>();
                cfg.CreateMap<ProjectTaskDTO, ProjectTaskVM>();
                cfg.CreateMap<UserVM, UserDTO>();
                cfg.CreateMap<UserDTO, UserVM>();
            });
            _mapper = new Mapper(config);
        }
        // GET: api/projects
        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Get a list of all projects
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [ResponseType(typeof(IEnumerable<ProjectVM>))]
        [HttpGet]
        [Route("projects")]
        public IHttpActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<ProjectVM>>(_projectService.GetAll()));
        }

        // GET: api/projects/5
        /// <summary>
        /// Get project by id
        /// </summary>
        /// <remarks>
        /// Get a project by id
        /// </remarks>
        /// <param name="id">Id of project</param>
        /// <returns></returns>
        /// <response code="200">Project found</response>
        /// <response code="404">Project not foundd</response>
        /// 
        [ResponseType(typeof(ProjectVM))]
        [HttpGet]
        [Route("projects/{id}", Name = "GetProject")]
        public IHttpActionResult Get(int id)
        {
            var projectVM = _mapper.Map<ProjectVM>(_projectService.GetById(id));
            if (projectVM == null)
            {
                return NotFound();
            }
            return Ok(projectVM);
        }
        // GET: api/projects/5/tasks
        /// <summary>
        /// Get project tasks by id
        /// </summary>
        /// <remarks>
        /// Get a project tasks by id
        /// </remarks>
        /// <param name="id">Id of project</param>
        /// <returns></returns>
        /// <response code="200">Project tasks found</response>
        /// <response code="404">Project tasks not found</response>
        /// 
        [ResponseType(typeof(IEnumerable<ProjectTaskVM>))]
        [HttpGet]
        [Route("projects/{id}/tasks")]
        public IHttpActionResult GetTasks(int id)
        {
            var projectVM = _mapper.Map<IEnumerable<ProjectTaskVM>>(_projectService.GetTasksByProjectId(id));
            if (projectVM == null)
            {
                return NotFound();
            }
            return Ok(projectVM);
        }

        // POST: api/projects/new
        /// <summary>
        /// Create a project
        /// </summary>
        /// <remarks>
        /// Create a new project
        /// </remarks>
        /// <param name="projectVM">Project for creation</param>
        /// <returns></returns>
        /// <response code="200">Project created</response>
        /// <response code="400">Bad request</response>
        [ResponseType(typeof(ProjectVM))]
        [HttpPost]
        [Route("projects/new")]
        public IHttpActionResult Post([FromBody] ProjectVM projectVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projectDTO = _mapper.Map<ProjectDTO>(projectVM);
            _projectService.Create(projectDTO);
            return CreatedAtRoute("GetProject", new { id = projectVM.Id }, projectVM);
        }

        // POST api/projects/update
        /// <summary>
        /// Update an existing project
        /// </summary>
        /// <param name="projectVM">Project to update</param>
        /// <returns></returns>
        /// <response code="200">Project updated</response>
        /// <response code="404">Project not found</response>
        [ResponseType(typeof(ProjectVM))]
        [HttpPost]
        [Route("projects/update")]
        public IHttpActionResult Put([FromBody]ProjectVM projectVM)
        {
            var sourceProject = _projectService.GetById(projectVM.Id);
            if (sourceProject == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projectDTO = _mapper.Map<ProjectDTO>(projectVM);
            _projectService.Update(projectDTO);
            return CreatedAtRoute("GetProject", new { id = projectVM.Id }, projectVM);
        }

        // POST api/projects/delete
        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Delete a project
        /// </remarks>
        /// <param name="projectVM">Project to delete</param>
        /// <returns></returns>
        /// <response code="200">Project deleted</response>
        /// <response code="404">Project not found</response>
        [HttpPost]
        [Route("projects/delete")]
        public IHttpActionResult Delete([FromBody]ProjectVM projectVM)
        {
            var sourceProject = _projectService.GetById(projectVM.Id);
            if (sourceProject == null)
            {
                return NotFound();
            }
            _projectService.Remove(sourceProject);
            return Ok();
        }

    }
}