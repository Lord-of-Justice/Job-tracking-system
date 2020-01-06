using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using TaskTrackingSystem.Ninject;
using Microsoft.Owin.Security.OAuth;
using System;
using TaskTrackingSystem.Provider;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(TaskTrackingSystem.App_Start.Startup))]

namespace TaskTrackingSystem.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration();
            webApiConfiguration.MapHttpAttributeRoutes();
            ConfigureOAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(webApiConfiguration);
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