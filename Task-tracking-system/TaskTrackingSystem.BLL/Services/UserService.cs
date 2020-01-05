using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.Infrastructure;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Interfaces;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace TaskTrackingSystem.BLL.Services
{
    public class UserService : IUserInterface
    {
        IUnitOfWork _db { get; set; }

        public UserService(IUnitOfWork uow)
        {
            _db = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await _db.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await _db.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await _db.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                UserProfile clientProfile = new UserProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                _db.UserProfileRepository.Create(clientProfile);
                await _db.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await _db.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await _db.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await _db.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await _db.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Remove(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            List<ApplicationUser> appList = _db.UserManager.Users.ToList();
            List<UserProfile> userProfile = _db.UserProfileRepository.GetAll().ToList();
            List<UserDTO> usersDTO = new List<UserDTO>();
            for(int i = 0; i < appList.Count(); i++)
            {
                UserDTO userDTO = new UserDTO() { Id = appList[i].Id, Email = appList[i].Email,
                    Address = userProfile[i].Address, Name = userProfile[i].Name, Password = appList[i].PasswordHash
                    , Role = _db.UserManager.GetRoles(appList[i].Id)[0], UserName = appList[i].UserName};
                usersDTO.Add(userDTO);
            }
            return usersDTO;
        }
    }
}
