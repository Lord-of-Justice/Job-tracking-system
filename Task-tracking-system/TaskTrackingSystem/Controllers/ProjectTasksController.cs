using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.Models;

namespace TaskTrackingSystem.Controllers
{
    [RoutePrefix("api")]
    public class ProjectTasksController : ApiController
    {
        private IService<ProjectTaskDTO> _projectTaskService;
        private IMapper _mapper;

        public ProjectTasksController(IService<ProjectTaskDTO> service)
        {
            _projectTaskService = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectTaskVM, ProjectTaskDTO>();
                cfg.CreateMap<ProjectTaskDTO, ProjectTaskVM>();
            });
            _mapper = new Mapper(config);
        }
        // GET: api/projecttask
        [HttpGet]
        [Route("projecttask")]
        public IEnumerable<ProjectTaskVM> Get()
        {
            return _mapper.Map<IEnumerable<ProjectTaskVM>>(_projectTaskService.GetAll());
        }

        // GET: api/projecttask/5
        [HttpGet]
        [Route("projecttask/{id}", Name = "GetProjectTask")]
        public IHttpActionResult Get(int id)
        {
            var projectTaskVM = _mapper.Map<ProjectTaskVM>(_projectTaskService.GetById(id));
            if (projectTaskVM == null)
            {
                return NotFound();
            }
            return Ok(projectTaskVM);
        }

        // POST: api/projecttask/new
        [HttpPost]
        [Route("projecttask/new")]
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

        // PUT api/projecttask/update
        [HttpPost]
        [Route("projecttask/update")]
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

        // DELETE api/projecttask/delete
        [HttpPost]
        [Route("projecttask/delete")]
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