using Serilog;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace HeroProject
{
    public class WebApiApplication : System.Web.HttpApplication
    {


        protected void Application_Start()
        {
            using (var log = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger())
            {
                log.Information("Hello, Serilog!");
                log.Warning("Goodbye, Serilog.");
            }

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HttpConfiguration config = GlobalConfiguration.Configuration;
        }


    }
}
