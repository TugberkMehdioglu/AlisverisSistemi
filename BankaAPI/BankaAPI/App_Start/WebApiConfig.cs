using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BankaAPI
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
                routeTemplate: "api/{controller}/{id}", //Sadece 1 tane action'ımız olduğu için url'e ayrıca action adı istemiyoruz
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
