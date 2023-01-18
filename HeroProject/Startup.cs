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

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44335/v1",
                DelayLoadMetadata = true

            });

            //app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            //{
            //    AuthenticationMode = AuthenticationMode.Active,
            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateIssuerSigningKey = true, // I guess you don't even have to sign the token
            //        ValidIssuer = "https://localhost:44335/core/connect/authorize",
            //        ValidAudience = "https://localhost:44335/core/connect/token",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jwt_signing_secret_key"))
            //    }
            //});
            //app.UseWebApi(config);
        }
    }
}