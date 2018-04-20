using Autofac;
using Autofac.Integration.Mvc;
using Framework.DAL.DataContext;
using Framework.DAL.EF;
using Framework.DAL.Repository;
using Framework.DAL.UnitOfWork;
using Framework.Web.Forms;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.UI.Forms;
using PlantDataMVC.UI.Forms.Handlers;
using System.Reflection;
using System.Web.Mvc;

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

            // ****************************************************
            // DAL configurations
            // ****************************************************
            builder.RegisterType<PlantDataDbContext>().As<IDataContextAsync>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();

            // ****************************************************
            // Core configurations
            // ****************************************************
            
            // Register services from PlantDataMVC.Service assembly.
            // i.e. when running assembly in same application
            builder.RegisterModule(new PlantDataMVC.Service.ServiceModule() { });

            // Register services from PlantDataMVC.WCFService assembly.
            //builder.RegisterModule(new PlantDataMVC.WCFService.WebServiceModule() { });

            // ****************************************************
            // UI configurations
            // ****************************************************
            // Register all types that implement IFormHandler<T> from given assembly
            var formAssembly = Assembly.GetAssembly(typeof(PlantCreateEditModelFormHandler));
            builder.RegisterAssemblyTypes(formAssembly)
                .AsClosedTypesOf(typeof(IFormHandler<>));

            // TEMP: Want to build factory via IoC itself
            builder.RegisterType<AutofacFormHandlerFactory>().As<IFormHandlerFactory>();

            // Register anonymous method that resolves FormHandlers based on type of form that they handle
            // Data service will be injected via registration of types implementing IBasicDataService<> 
            //builder.Register<Func<IF,IBasicDataService<IDomainEntity>>>(c => 
            //{
            //    var cc = c.Resolve<IComponentContext>();
            //    return ds => cc.Resolve<T>();
            //});



            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}