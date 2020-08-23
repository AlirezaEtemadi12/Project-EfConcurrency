using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using EfConcurrency.Common;
using EfConcurrency.ServicesLayer.Configs;
using EfConcurrency.Web.FilterAttribute;

namespace EfConcurrency.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Structure Map Config
            var container = StructureMapConfig.Container;
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), new StructureMapHttpControllerActivator(container));
            //------------------------------


            // filterAttribute
            config.Filters.Add(new CustomExceptionFilter());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            //------------------------------

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: $"{ConstantSettings.ApiVersion}/{{controller}}/{{id}}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
