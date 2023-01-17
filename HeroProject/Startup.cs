using Microsoft.Owin;
using Owin;
using IdentityServer3.AccessTokenValidation;
using System.Web.Http;
using Microsoft.Owin.Security.Jwt;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using System.Text;
using Microsoft.Owin.Security.OAuth;
using System;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(HeroProject.Startup))]

namespace HeroProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44335/v1",
                DelayLoadMetadata = true

            });
        
        }
    }
}