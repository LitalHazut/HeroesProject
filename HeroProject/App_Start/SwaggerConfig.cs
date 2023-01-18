using System.Web.Http;
using WebActivatorEx;
using HeroProject;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace HeroProject
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var containingAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration

                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "HeroProject");

                    c.OAuth2("oauth2")
                        .Description("OAuth2 Implicit Grant")
                        .Flow("implicit")
                        .AuthorizationUrl("https://localhost:44335/core/connect/authorize")
                        .TokenUrl("https://localhost:44335/core/connect/token")
                        .Scopes(scopes =>
                        {
                            scopes.Add("read", "Read access to protected resources");
                            scopes.Add("write", "Write access to protected resources");
                        });

                    c.OperationFilter<AssignOAuth2SecurityRequirements>();
                    

                }).EnableSwaggerUi(c =>
                {
                    c.EnableOAuth2Support("implicitclient", "secret", "test", "Swagger UI");
                    c.InjectJavaScript(containingAssembly, "HeroProject.SwaggerExtensions.fixOAuthScopeSeparator.js");
                    
                });

        }
    }

}