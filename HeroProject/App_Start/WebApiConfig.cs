using Serilog;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity;
using HeroProject.Repositories;
using HeroProject.Repositories.Interfaces;
using Unity;
using Unity.Lifetime;

namespace HeroProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();
            container.RegisterType<IHeroRepository, HeroRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrainerRepository, TrainerRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

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
