using Autofac;
using Autofac.Integration.Mvc;
using Framework.DAL.EF.UnitOfWork;
using Framework.DAL.UnitOfWork;
using Framework.Service.ServiceLayer;
using PlantDataMVC.Service.SimpleServiceLayer;
using System.Web.Mvc;
using PlantDataMVC.UI.Helpers;

namespace PlantDataMVC.UI
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {

            var builder = new ContainerBuilder();

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


            // DAL configurations
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            // Core configurations
            builder.RegisterType<SimpleServiceLayer>().As<IServiceLayer>();


            // UI configurations
            // TEMP: Want to build factory via IoC itself
            builder.RegisterType<FormHandlerFactory>().As<IFormHandlerFactory>();


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}