using Framework.Web.Core.Forms;
using Framework.Web.Core.Mediator;
using Framework.Web.Core.Views;
using Microsoft.Extensions.DependencyInjection;
using PlantDataMVC.UICore.Handlers;
using System;
using System.Linq;
using System.Reflection;

namespace PlantDataMVC.UICore.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Configures IOC services for main domain.
        /// </summary>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // ****************************************************
            // UI configurations
            // ****************************************************
            // Register mediator
            //builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            services.AddScoped<IMediator, Mediator>();

            // Register all types that implement IFormHandler<T,U> from given assembly
            Assembly formAssembly = Assembly.GetAssembly(typeof(Handlers.Forms.Plant.PlantCreateEditModelFormHandler));
            services.AddImplementedInterfacesFromAssembly(formAssembly, typeof(IFormHandler<,>));

            services.AddScoped<IFormHandlerFactory, FormHandlerFactory>();

            // Register all types that implement IQueryHandler<T,U> from given assembly
            Assembly viewAssembly = Assembly.GetAssembly(typeof(Handlers.Views.Genus.ShowQueryHandler));
            services.AddImplementedInterfacesFromAssembly(viewAssembly, typeof(IQueryHandler<,>)); 

            services.AddScoped<IQueryHandlerFactory, QueryHandlerFactory>();

            return services;
        }

        public static IServiceCollection AddImplementedInterfacesFromAssembly(this IServiceCollection services, Assembly assembly, Type genericInterfaceType)
        {
            // Implement equivalent of:
            // builder.RegisterAssemblyTypes(formAssembly).AsClosedTypesOf(typeof(IFormHandler<,>)).AsImplementedInterfaces();

            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            if (genericInterfaceType == null)
                throw new ArgumentNullException(nameof(genericInterfaceType));

            var typesWithGenericInterface = assembly.GetLoadableTypes().Where(t => !t.IsAbstract && !t.IsInterface && t.GetInterfaces().Any(i => i.IsGenericType)).ToList();

            foreach (var genericType in typesWithGenericInterface)
            {
                var implementedGenericInterfaces = genericType.GetInterfaces().Where(i => i.IsGenericType).ToList();
                foreach (var implementedInterface in implementedGenericInterfaces)
                {
                    if (genericInterfaceType.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition()))
                    {
                        services.AddScoped(implementedInterface, genericType);
                        //Console.WriteLine($"Adding {genericType.Name} as implementation of {implementedInterface.FullName}"); 
                    }
                }
            }

            return services;
        }

    }
}