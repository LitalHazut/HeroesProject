using Serilog;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity;

namespace HeroProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(DefaultAuthenticationTypes.ExternalBearer));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",

                defaults: new { id = RouteParameter.Optional }

            );
        }
    }
}
