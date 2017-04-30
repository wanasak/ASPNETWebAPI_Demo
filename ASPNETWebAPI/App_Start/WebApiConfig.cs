using ASPNETWebAPI.App_Start;
using ASPNETWebAPI.Core;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ASPNETWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Change JSON data to be indented
           config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // Change JSON data to be camel case
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Return JSON only
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Return XML only
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            // Return JSON data when a request is made for text/html
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Register custom format 
            config.Formatters.Add(new CustomJsonFormatter());

            // Register 
            config.Filters.Add(new RequiredHttpsAttribute());

            // Register basic authen across the entire web api
            //config.Filters.Add(new BasicAuthenticationAttribute());
        }
    }
}
