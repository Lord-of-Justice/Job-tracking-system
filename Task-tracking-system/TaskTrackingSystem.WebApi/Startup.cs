using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using TaskTrackingSystem.WebApi.Ninject;
using Microsoft.Owin.Security.OAuth;
using System;
using TaskTrackingSystem.WebApi.Providers;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(TaskTrackingSystem.WebApi.Startup))]
namespace TaskTrackingSystem.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);

            app.UseWebApi(config);
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthBearerTokens(OAuthServerOptions);
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        private static StandardKernel CreateKernel()
        {
            return new StandardKernel(new NinjectBinding());
        }
    }
}