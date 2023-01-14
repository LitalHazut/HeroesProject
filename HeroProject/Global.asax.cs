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

            var log = new LoggerConfiguration()
            .WriteTo.File(@"\Logs\log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            Log.Logger = log;
           
        }


    }
}
