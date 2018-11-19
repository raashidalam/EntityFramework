using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;


namespace StackOverFlow
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
              name: "DefaultApiwithaction",
              routeTemplate: "api/{controller}/{action}",
              defaults: null
          );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // config.EnableQuerySupport();
            //   config.Routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
