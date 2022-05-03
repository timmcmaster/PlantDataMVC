using Microsoft.Extensions.DependencyInjection;
using Framework.Web.Core.Mediator;
using Framework.Web.Core.Forms;
using Framework.Web.Core.Mvc;
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

            // Register all types that implement IFormHandler<T> from given assembly
            //Assembly formAssembly = Assembly.GetAssembly(typeof(PlantCreateEditModelFormHandler));
            //builder.RegisterAssemblyTypes(formAssembly).AsClosedTypesOf(typeof(IFormHandler<,>)).AsImplementedInterfaces();

            //// TEMP: Want to build factory via IoC itself
            //builder.RegisterType<AutofacFormHandlerFactory>().As<IFormHandlerFactory>();

            //// Register anonymous method that resolves FormHandlers based on type of form that they handle
            //// Data service will be injected via registration of types implementing IDataServiceBase<> 
            ////builder.Register<Func<IF,IDataServiceBase<IDomainEntity>>>(c => 
            ////{
            ////    var cc = c.Resolve<IComponentContext>();
            ////    return ds => cc.Resolve<T>();
            ////});

            //// Register all types that implement IQueryHandler<T,U> from given assembly
            //Assembly viewAssembly = Assembly.GetAssembly(typeof(ShowQueryHandler));
            //builder.RegisterAssemblyTypes(viewAssembly).AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces();
            ////builder.RegisterAssemblyTypes(viewAssembly).AsImplementedInterfaces();

            //// TEMP: Want to build factory via IoC itself
            //builder.RegisterType<AutofacQueryHandlerFactory>().As<IQueryHandlerFactory>();

            //// Register HttpClient as a service to be injected
            //builder.RegisterType<MyHttpClientFactory>().As<IHttpClientFactory>().SingleInstance();


            return services;
        }
    }
}