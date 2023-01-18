using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IdentityServer3.AccessTokenValidation;

//[assembly: OwinStartup(typeof(HeroProject.Startup))]

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
                Authority = "https://localhost:44335/api",
                DelayLoadMetadata = true,
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