using Framework.Web.Core.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

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
            /*
            // Register mediator
            services.AddScoped<IMediator, Mediator>();

            // Register all types that implement IFormHandler<T,U> from given assembly
            Assembly formAssembly = Assembly.GetAssembly(typeof(Handlers.Forms.Genus.GenusCreateEditModelFormHandler));
            services.AddImplementedInterfacesFromAssembly(formAssembly, typeof(IFormHandler<,>));

            services.AddScoped<IFormHandlerFactory, FormHandlerFactory>();

            // Register all types that implement IQueryHandler<T,U> from given assembly
            Assembly viewAssembly = Assembly.GetAssembly(typeof(Handlers.Views.Genus.ShowQueryHandler));
            services.AddImplementedInterfacesFromAssembly(viewAssembly, typeof(IQueryHandler<,>)); 

            services.AddScoped<IQueryHandlerFactory, QueryHandlerFactory>();
            */

            /// Extensions to scan for MediatR handlers and registers them.
            /// - Scans for any handler interface implementations and registers them as <see cref="ServiceLifetime.Transient"/>
            /// - Scans for any <see cref="IRequestPreProcessor{TRequest}"/> and <see cref="IRequestPostProcessor{TRequest,TResponse}"/> implementations and registers them as transient instances
            /// Registers <see cref="ServiceFactory"/> and <see cref="IMediator"/> as transient instances
            /// After calling AddMediatR you can use the container to resolve an <see cref="IMediator"/> instance.
            /// This does not scan for any <see cref="IPipelineBehavior{TRequest,TResponse}"/> instances including <see cref="RequestPreProcessorBehavior{TRequest,TResponse}"/> and <see cref="RequestPreProcessorBehavior{TRequest,TResponse}"/>.
            /// To register behaviors, use the <see cref="ServiceCollectionServiceExtensions.AddTransient(IServiceCollection,Type,Type)"/> with the open generic or closed generic types.            
            services.AddMediatR(typeof(Handlers.Forms.Genus.GenusCreateEditModelFormHandler), typeof(Handlers.Views.Genus.ShowQueryHandler));

            // Before we leave this method, write our registrations to log file
            services.LogRegisteredServices(Log.Logger);

            return services;
        }
    }
}