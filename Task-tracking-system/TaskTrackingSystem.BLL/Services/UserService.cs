using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.Infrastructure;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.DAL.Entities;
using TaskTrackingSystem.DAL.Interfaces;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace TaskTrackingSystem.BLL.Services
{
    public class UserService : IUserInterface
    {
        private IMapper _mapper;
        public UserService(IUnitOfWork uow)
        {
            Db = uow;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserProfile, UserDTO>();
                cfg.CreateMap<UserDTO, UserProfile>();

                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<UserDTO, ApplicationUser>();

                cfg.CreateMap<ApplicationRole, UserDTO>();
                cfg.CreateMap<UserDTO, ApplicationRole>();
            });
            _mapper = new Mapper(config);
        }
        IUnitOfWork Db { get; set; }
        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Db.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Db.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                await Db.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                UserProfile clientProfile = new UserProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                Db.UserProfileRepository.Create(clientProfile);
                await Db.SaveAsync();
                return new OperationDetails(true, "Registration successful", "");
            }
            else
            {
                return new OperationDetails(false, "User with this id is alreade in db", "Email");
            }
        }

        public async Task<UserDTO> Authenticate(string userName, string password)
        {
            ClaimsIdentity claim = null;
            ApplicationUser userApp = await Db.UserManager.FindAsync(userName, password);
            UserDTO userDTO = createUserDTO(userApp, new UserProfile());
            return userDTO;
            //if (user != null)
            //    claim = await Db.UserManager.CreateIdentityAsync(user,
            //                                DefaultAuthenticationTypes.ApplicationCookie);
            //return claim;
        }
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Db.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Db.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void Remove(UserDTO userDTO)
        {
            var appUser = Db.UserManager.FindById(userDTO.Id);
            appUser = _mapper.Map(userDTO, appUser);
            Db.UserManager.Delete(appUser);
            Db.SaveChanges();
        }

        public void Update(UserDTO userDTO)
        {
            var userProfile = Db.UserProfileRepository.GetById(userDTO.Id);
            userProfile = _mapper.Map(userDTO, userProfile);
            Db.UserProfileRepository.Update(userProfile);
            
            var appUser = Db.UserManager.FindById(userDTO.Id);
            // for updating role
            var oldRoleId = appUser.Roles.SingleOrDefault().RoleId;
            var oldRoleName = Db.RoleManager.FindById(oldRoleId).Name;
            if (oldRoleName != userDTO.Role)
            {
                Db.UserManager.RemoveFromRole(userDTO.Id, oldRoleName);
                Db.UserManager.AddToRole(userDTO.Id, userDTO.Role);
            }
            appUser = _mapper.Map(userDTO, appUser);
            Db.UserManager.Update(appUser);
            Db.SaveChanges();
        }

        public UserDTO GetUserById(string id)
        {
            ApplicationUser appUser = Db.UserManager.FindById(id);
            UserProfile profile = Db.UserProfileRepository.GetById(id);
            return createUserDTO(appUser, profile);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            List<ApplicationUser> appList = Db.UserManager.Users.ToList();
            List<UserProfile> userProfile = Db.UserProfileRepository.GetAll().ToList();
            List<UserDTO> usersDTO = new List<UserDTO>();
            for(int i = 0; i < appList.Count(); i++)
            {                
                usersDTO.Add(createUserDTO(appList[i], userProfile[i]));
            }
            return usersDTO;
        }

        private UserDTO createUserDTO(ApplicationUser appUser, UserProfile profile) 
        {
            return new UserDTO()
            {
                Id = appUser.Id,
                Email = appUser.Email,
                Address = profile.Address,
                Name = profile.Name,
                Password = appUser.PasswordHash,
                Role = Db.UserManager.GetRoles(appUser.Id)[0],
                UserName = appUser.UserName
            };
        }
    }
}
