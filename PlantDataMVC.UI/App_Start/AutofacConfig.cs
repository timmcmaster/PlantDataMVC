using Autofac;
using Autofac.Integration.Mvc;
using Framework.DAL.DataContext;
using Framework.DAL.EF;
using Framework.DAL.Entity;
using Framework.DAL.Repository;
using Framework.DAL.UnitOfWork;
using Framework.Service.ServiceLayer;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Service.SimpleServiceLayer;
using PlantDataMVC.UI.Helpers;
using System;
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


            // DAL configurations
            builder.RegisterType<PlantDataDbContext>().As<IDataContextAsync>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();
            // Register repository types for now
            // TODO: Make factory instead, manage lifetime scope
            builder.RegisterGeneric(typeof(Framework.DAL.EF.Repository<>))
                .As(typeof(IRepositoryAsync<>));


            // Core configurations
            //builder.RegisterType<SimpleServiceLayer>().As<IServiceLayer>();
            
            // Register all classes that implement BasicDataService<T> as IBasicDataService<T>
            // TODO: This doesn't work, as BasicDataService is abstract 
            builder.RegisterGeneric(typeof(BasicDataService<>))
                .As(typeof(IBasicDataService<>));

            // Register 
            builder.Register<Func<T,IBasicDataService<T>>>(c => 
            {
                var cc = c.Resolve<IComponentContext>();
                return ds => cc.Resolve<T>();
            });


            // UI configurations
            // TEMP: Want to build factory via IoC itself
            builder.RegisterType<FormHandlerFactory>().As<IFormHandlerFactory>();


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}