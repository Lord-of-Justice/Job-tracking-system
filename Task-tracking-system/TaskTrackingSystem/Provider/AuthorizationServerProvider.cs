using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskTrackingSystem.BLL.Services;
using TaskTrackingSystem.BLL.DTO;
using TaskTrackingSystem.DAL.Repositories;

namespace TaskTrackingSystem.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //UserDTO userDTO = null;
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            using (UserService _userService = new UserService(new UnitOfWork("DefaultConnection")))
            {
                UserDTO userDTO = await _userService.Authenticate(context.UserName, context.Password);
                
                if (userDTO == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }


                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, userDTO.Role));

                context.Validated(identity);
            }

        }
    }
}