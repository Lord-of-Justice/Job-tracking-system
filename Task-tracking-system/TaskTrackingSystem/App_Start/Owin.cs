using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using TaskTrackingSystem.BLL.Services;
using Microsoft.AspNet.Identity;
using TaskTrackingSystem.BLL.Interfaces;
using System.Reflection;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using TaskTrackingSystem.Ninject;

[assembly: OwinStartup(typeof(TaskTrackingSystem.App_Start.Startup))]

namespace TaskTrackingSystem.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        /// <summary>
        /// Creates a configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext<IUserInterface>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            /*var webApiConfiguration = new HttpConfiguration();
            webApiConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "values" });

            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(webApiConfiguration);*/

            var webApiConfiguration = new HttpConfiguration();
            webApiConfiguration.MapHttpAttributeRoutes();
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(webApiConfiguration);
        }
        private static StandardKernel CreateKernel()
        {
            return new StandardKernel(new NinjectBinding());
        }


        private IUserInterface CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }

        /// <summary>
        /// Creates the kernel.
        /// </summary>
        /// <returns>the newly created kernel.</returns>
        /*private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }*/
        
    }
}