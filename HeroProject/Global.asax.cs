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
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HttpConfiguration config = GlobalConfiguration.Configuration;


            //var log = new LoggerConfiguration()
            // .WriteTo.File(System.Web.Hosting.HostingEnvironment.MapPath("~/bin/Logs/log.txt"))
            // .CreateLogger();
            //log.Information("Hello - Application_Start");
        }


    }
}
