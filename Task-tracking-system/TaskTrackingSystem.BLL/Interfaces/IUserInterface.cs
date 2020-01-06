using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.BLL.Infrastructure;

namespace TaskTrackingSystem.BLL.Interfaces
{
    public interface IUserInterface : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        void Remove(UserDTO userDTO);
        void Update(UserDTO userDTO);
        UserDTO GetUserById(string id);
        IEnumerable<UserDTO> GetAll();
    }
}
