using Microsoft.Owin;
using Owin;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(HeroProject.Startup))]

namespace HeroProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // token validation
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44335/core",
                 DelayLoadMetadata = true
            });
            
        }

    }
}