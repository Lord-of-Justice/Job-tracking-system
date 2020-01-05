using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.BLL.Services;
using TaskTrackingSystem.Models;
using AutoMapper;

namespace TaskTrackingSystem.Controllers
{

    [Route("api/users")]
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
        public IEnumerable<UserVM> Get()
        {
            return _mapper.Map<IEnumerable<UserVM>>(_userService.GetAll());
        }

        // GET api/users/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var user = _mapper.Map<UserVM>(_userService.GetUserById(id));

            if (user == null)
            {
                
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}