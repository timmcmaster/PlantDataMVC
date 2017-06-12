using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.EF.Infrastructure;
using PlantDataMVC.Core.SimpleServiceLayer;
using PlantDataMVC.Core.ServiceLayer;

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
            //builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();


            // Core configurations
            builder.RegisterType<SimpleServiceLayer>().As<IServiceLayer>();


            // UI configurations



            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}