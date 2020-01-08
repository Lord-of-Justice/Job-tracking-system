using System.Threading.Tasks;
using System.Web.Http;
using TaskTrackingSystem.WebApi.Models;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.Infrastructure;
using TaskTrackingSystem.BLL.DTO;
using System.Collections.Generic;

namespace TaskTrackingSystem.WebApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class UserAccountController : ApiController
    {
        private IUserInterface _userService;
        public UserAccountController(IUserInterface service)
        {
            _userService = service;
        }
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserDTO userDto = new UserDTO
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                Password = userModel.Password,
                Address = userModel.Address,
                Name = userModel.Name,
                Role = "client"
            };
            OperationDetails operationDetails = await _userService.Create(userDto);
            if (!operationDetails.Succedeed)
            {
                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                return BadRequest(ModelState);
            }
            return Ok();

        }
        private async Task SetInitialDataAsync()
        {
            await _userService.SetInitialData(new UserDTO
            {
                Email = "admin@gmail.com",
                UserName = "ADMIN",
                Password = "123admin321",
                Name = "Admin",
                Address = "Коморка під сходами",
                Role = "admin",
            }, new List<string> { "admin", "manager", "employee", "client" });
        }
    }
}