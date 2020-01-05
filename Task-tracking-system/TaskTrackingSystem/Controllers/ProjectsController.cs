using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Http;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.BLL.Services;
using TaskTrackingSystem.Models;
using AutoMapper;

namespace TaskTrackingSystem.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private IService<ProjectDTO> _projectService;
        private IMapper _mapper;

        public ProjectsController(IService<ProjectDTO> service)
        {
            _projectService = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectVM, ProjectDTO>();
                cfg.CreateMap<ProjectDTO, ProjectVM>();
            });
            _mapper = new Mapper(config);
        }
        // GET: api/Project
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<ProjectVM> Get()
        {
            return _mapper.Map<IEnumerable<ProjectVM>>(_projectService.GetAll());
        }

        // GET: api/Project/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var projectVM = _mapper.Map<ProjectVM>(_projectService.GetById(id));
            if (projectVM == null)
            {
                return NotFound();
            }
            return Ok(projectVM);
        }

        // POST: api/Project
        [HttpPost]
        public IHttpActionResult Post([FromBody] ProjectVM project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            var projectDTO = _mapper.Map<ProjectDTO>(project);
            _projectService.Create(projectDTO);
            return CreatedAtRoute("Get", new { id = project.Id }, project);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}