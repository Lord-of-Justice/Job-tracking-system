using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface IUserService
    {
        void Create(UserDTO userDTO);
        void Remove(UserDTO userDTO);
        void Update(UserDTO userDTO);
        UserDTO GetUserById(int id);
    }
}
