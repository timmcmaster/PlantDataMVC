using System.Net.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Framework.Web.Forms;
using System.Reflection;
using Framework.Web.Mediator;
using Framework.Web.Views;
using PlantDataMVC.UI.Handlers;
using PlantDataMVC.UI.Handlers.Forms;
using PlantDataMVC.UI.Handlers.Views;
using PlantDataMVC.UI.Helpers;

namespace PlantDataMVC.UI
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // ****************************************************
            // MVC configurations
            // ****************************************************
            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            //builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            //builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            //builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();


            // ****************************************************
            // UI configurations
            // ****************************************************
            // Register mediator
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            // Register all types that implement IFormHandler<T> from given assembly
            Assembly formAssembly = Assembly.GetAssembly(typeof(PlantCreateEditModelFormHandler));
            builder.RegisterAssemblyTypes(formAssembly).AsClosedTypesOf(typeof(IFormHandler<,>)).AsImplementedInterfaces();

            // TEMP: Want to build factory via IoC itself
            builder.RegisterType<AutofacFormHandlerFactory>().As<IFormHandlerFactory>();

            // Register anonymous method that resolves FormHandlers based on type of form that they handle
            // Data service will be injected via registration of types implementing IDataServiceBase<> 
            //builder.Register<Func<IF,IDataServiceBase<IDomainEntity>>>(c => 
            //{
            //    var cc = c.Resolve<IComponentContext>();
            //    return ds => cc.Resolve<T>();
            //});

            // Register all types that implement IViewHandler<T,U> from given assembly
            Assembly viewAssembly = Assembly.GetAssembly(typeof(GenusShowViewModelHandler));
            builder.RegisterAssemblyTypes(viewAssembly).AsClosedTypesOf(typeof(IViewHandler<,>)).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(viewAssembly).AsImplementedInterfaces();

            // TEMP: Want to build factory via IoC itself
            builder.RegisterType<AutofacViewHandlerFactory>().As<IViewHandlerFactory>();

            // Register HttpClient as a service to be injected
            builder.RegisterType<MyHttpClientFactory>().As<IMyHttpClientFactory>().SingleInstance();

            return builder.Build();
        }
    }
}