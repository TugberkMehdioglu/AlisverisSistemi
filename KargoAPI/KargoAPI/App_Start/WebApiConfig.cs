using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KargoAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*"); //API'ımızın belirlediğimiz sitelerle haberleşme yapabilmesi için gereken ayarları yaptık

            config.EnableCors(cors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}", //Buraya {action} ekledik çünkü; birden fazla action'ımız olduğundan, gelen request'lerde action belirtmesini zorunlu kıldık
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
