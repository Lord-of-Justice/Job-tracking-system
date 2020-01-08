using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.WebApi.Models;
using AutoMapper;

namespace TaskTrackingSystem.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        private IUserInterface _userService;
        private IMapper _mapper;
        public UsersController(IUserInterface service)
        {
            _userService = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserVM, UserDTO>();
                cfg.CreateMap<UserDTO, UserVM>();
            });
            _mapper = new Mapper(config);
        }
        // GET api/users
        [HttpGet]
        [Route("users")]
        public IEnumerable<UserVM> Get()
        {
            return _mapper.Map<IEnumerable<UserVM>>(_userService.GetAll());
        }

        // GET api/users/5
        [HttpGet]
        [Route("users/{id}", Name = "GetUser")]
        public IHttpActionResult Get(string id)
        {
            var user = _mapper.Map<UserVM>(_userService.GetUserById(id));

            if (user == null)
            {

                return NotFound();
            }

            return Ok(user);
        }

        // POST api/users/update
        [HttpPost]
        [Route("users/update")]
        public IHttpActionResult Put([FromBody]UserVM userVM)
        {
            var sourceProject = _userService.GetUserById(userVM.Id);
            if (sourceProject == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDTO = _mapper.Map<UserDTO>(userVM);
            _userService.Update(userDTO);
            return CreatedAtRoute("GetProject", new { id = userVM.Id }, userVM);
        }

        // POST api/users/delete
        [HttpPost]
        [Route("users/delete")]
        public IHttpActionResult Delete([FromBody]UserVM userVM)
        {
            var sourceProject = _userService.GetUserById(userVM.Id);
            if (sourceProject == null)
            {
                return NotFound();
            }
            _userService.Remove(sourceProject);
            return Ok();
        }
    }
}