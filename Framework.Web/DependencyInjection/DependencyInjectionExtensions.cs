using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Framework.Web.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddImplementedInterfacesFromAssembly(this IServiceCollection services, Assembly assembly, Type genericInterfaceType)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            if (genericInterfaceType == null)
                throw new ArgumentNullException(nameof(genericInterfaceType));

            var typesWithGenericInterface = assembly.GetLoadableTypes().Where(t => !t.IsAbstract && !t.IsInterface && t.GetInterfaces().Any(i => i.IsGenericType)).ToList();

            foreach (var genericType in typesWithGenericInterface)
            {
                var implementedGenericInterfacesOfCorrectType = genericType
                    .GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Where(i => genericInterfaceType.IsAssignableFrom(i.GetGenericTypeDefinition()));

                foreach (var implementedInterface in implementedGenericInterfacesOfCorrectType)
                {
                    services.AddScoped(implementedInterface, genericType);
                }
            }

            return services;
        }

        public static IServiceCollection LogRegisteredServices(this IServiceCollection services, Serilog.ILogger logger)
        {
            logger.Information($"Total Services Registered: {services.Count}");
            foreach (var service in services)
            {
                logger.Information(
                    $"Service: {service.ServiceType.FullName}\n" +
                    $"Service Friendly Name : {service.ServiceType.GetFriendlyName(useFullName: true)}\n" +
                    $"Lifetime: {service.Lifetime}\n" +
                    $"Instance: {service.ImplementationType?.FullName}");
            }

            return services;
        }

        public static string GetFriendlyName(this Type type, bool useFullName = false)
        {
            if (type == typeof(int))
                return "int";
            else if (type == typeof(short))
                return "short";
            else if (type == typeof(byte))
                return "byte";
            else if (type == typeof(bool))
                return "bool";
            else if (type == typeof(long))
                return "long";
            else if (type == typeof(float))
                return "float";
            else if (type == typeof(double))
                return "double";
            else if (type == typeof(decimal))
                return "decimal";
            else if (type == typeof(string))
                return "string";
            else if (type.IsGenericType)
                return type.Name.Split('`')[0] + "<" + string.Join(", ", type.GetGenericArguments().Select(x => GetFriendlyName(x)).ToArray()) + ">";
            else
                return useFullName ? type.FullName : type.Name;
        }
    }
}