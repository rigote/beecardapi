using BeeCard.API.DependencyResolution;
using BeeCard.API.Providers;
using BeeCard.Application.Interfaces;
using BeeCard.Utils.DependencyInjection.DependencyResolution;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using StructureMap;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(BeeCard.API.Startup))]
namespace BeeCard.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IContainer container = IoC.Initialize();
            container.AssertConfigurationIsValid();
            ConfigureOAuth(app, container);
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IContainer container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(container.GetInstance<IUserAppService>())
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}