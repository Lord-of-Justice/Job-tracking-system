using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Http;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.Models;
using AutoMapper;

namespace TaskTrackingSystem.Controllers
{
    [RoutePrefix("api")]
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
                cfg.CreateMap<UserVM, UserDTO>();
                cfg.CreateMap<UserDTO, UserVM>();
            });
            _mapper = new Mapper(config);
        }
        // GET: api/projects
        [HttpGet]
        [Route("projects")]
        public IEnumerable<ProjectVM> Get()
        {
            return _mapper.Map<IEnumerable<ProjectVM>>(_projectService.GetAll());
        }

        // GET: api/projects/5
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

        // POST: api/projects/new
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