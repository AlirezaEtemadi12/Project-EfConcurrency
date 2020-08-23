using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using EfConcurrency.Common;
using EfConcurrency.ServicesLayer.Configs;
using StructureMap.Web.Pipeline;

namespace EfConcurrency.Web
{
    public class Global : HttpApplication
    {
        public class WebApiApplication : HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                AutoMapperConfig.RegisterAutoMapper();

                ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            }

            protected void Application_EndRequest(object sender, EventArgs e)
            {
                HttpContextLifecycle.DisposeAndClearAll();
            }
        }

        public class StructureMapControllerFactory : DefaultControllerFactory
        {
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                if (controllerType == null)
                    throw new HttpException(404, ConstantSettings.NotFoundHttp);
                return StructureMapConfig.Container.GetInstance(controllerType) as Controller;
            }
        }
    }
}