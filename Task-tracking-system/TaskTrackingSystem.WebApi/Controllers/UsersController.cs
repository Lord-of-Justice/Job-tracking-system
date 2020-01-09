using System.Collections.Generic;
using System.Web.Http;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.WebApi.Models;
using AutoMapper;
using System.Web.Http.Description;

namespace TaskTrackingSystem.WebApi.Controllers
{
    /// <summary>
    /// Users api
    /// </summary>
    [Authorize(Roles = "admin, manager, employee")]
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        private IUserInterface _userService;
        private IMapper _mapper;
        /// <summary>
        /// UsersController constructor
        /// </summary>
        /// <param name="service">Service for crud users</param>
        public UsersController(IUserInterface service)
        {
            _userService = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserVM, UserDTO>();
                cfg.CreateMap<UserDTO, UserVM>();

                cfg.CreateMap<ProjectTaskVM, ProjectTaskDTO>();
                cfg.CreateMap<ProjectTaskDTO, ProjectTaskVM>();
            });
            _mapper = new Mapper(config);
        }
        // GET api/users
        /// <summary>
        /// Get all users
        /// </summary>
        /// <remarks>
        /// Get a list of all users
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [ResponseType(typeof(IEnumerable<UserVM>))]
        [HttpGet]
        [Route("users")]
        public IHttpActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<UserVM>>(_userService.GetAll()));
        }

        // GET api/users/5
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <remarks>
        /// Get a user by id
        /// </remarks>
        /// <param name="id">Id (string) of user</param>
        /// <returns></returns>
        /// <response code="200">User found</response>
        /// <response code="404">User not foundd</response>
        [ResponseType(typeof(UserVM))]
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

        // GET: api/users/5/tasks
        /// <summary>
        /// Get user tasks by id
        /// </summary>
        /// <remarks>
        /// Get a user tasks by id
        /// </remarks>
        /// <param name="id">Id of user</param>
        /// <returns></returns>
        /// <response code="200">User tasks found</response>
        /// <response code="404">User tasks not found</response>
        /// 
        [ResponseType(typeof(IEnumerable<ProjectTaskVM>))]
        [HttpGet]
        [Route("users/{id}/tasks")]
        public IHttpActionResult GetTasks(string id)
        {
            var projectVM = _mapper.Map<IEnumerable<ProjectTaskVM>>(_userService.GetTasksByEnployeeId(id));
            if (projectVM == null)
            {
                return NotFound();
            }
            return Ok(projectVM);
        }

        // POST api/users/update
        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="userVM">User to update</param>
        /// <returns></returns>
        /// <response code="200">User updated</response>
        /// <response code="404">User not found</response>
        [ResponseType(typeof(UserVM))]
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
        /// <summary>
        /// Delete a user
        /// </summary>
        /// <remarks>
        /// Delete a user
        /// </remarks>
        /// <param name="userVM">User to delete</param>
        /// <returns></returns>
        /// <response code="200">User deleted</response>
        /// <response code="404">User not found</response>
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