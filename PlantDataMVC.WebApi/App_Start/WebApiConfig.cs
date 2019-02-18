using Autofac;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac.Integration.WebApi;
using PlantDataMVC.WebApi.Mappers;

namespace PlantDataMVC.WebApi
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            // Web API configuration and services
            var config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));

            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Enable Cross-origin resource sharing if browser client on different domain to API and using AJAX calls
            // This can be set here or at controller or method level
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Set the dependency resolver to be Autofac.
            IContainer container = AutofacConfig.ConfigureContainer();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Configure mappings for all objects
            AutoMapperBootstrapper.Initialize();

            return config;
        }
    }
}
