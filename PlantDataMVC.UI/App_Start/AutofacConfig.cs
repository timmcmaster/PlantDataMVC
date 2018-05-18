using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using ClientProxies;
using Framework.DAL.EF;
using Framework.Web.Forms;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.Service.SimpleServiceLayer;
using PlantDataMVC.UI.Forms;
using PlantDataMVC.UI.Forms.Handlers;
using System.Reflection;
using System.ServiceModel;
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
            //var svcAssembly = typeof(PlantDataService).Assembly;
            //builder.RegisterAssemblyTypes(svcAssembly).AsClosedTypesOf(typeof(IDataServiceBase<>));

            // Required service is now IPlantDataService instead of IDataServiceBase<Plant>
            // Register specific services for now
            builder.RegisterType<PlantDataService>().As<IPlantDataService>();
            builder.RegisterType<PlantProductTypeDataService>().As<IPlantProductTypeDataService>();
            builder.RegisterType<PlantSeedDataService>().As<IPlantSeedDataService>();
            builder.RegisterType<PlantSeedSiteDataService>().As<IPlantSeedSiteDataService>();
            builder.RegisterType<PlantSeedTrayDataService>().As<IPlantSeedTrayDataService>();
            builder.RegisterType<PlantStockEntryDataService>().As<IPlantStockEntryDataService>();
            builder.RegisterType<PlantStockTransactionDataService>().As<IPlantStockTransactionDataService>();
            builder.RegisterType<PlantStockTransactionTypeDataService>().As<IPlantStockTransactionTypeDataService>();

            // ****************************************************
            // WCF Service configurations
            // ****************************************************

            /* TODO: Fix registration of WCF services
             * 
            // Register channel factory (for all generic types?)
            builder.Register(c => new ChannelFactory<IDataServiceBase<Plant>>(
                                    new BasicHttpBinding(), 
                                    new EndpointAddress("http://localhost:57889/")));

            // Register client proxies (for all generic types?)
            var wcfClientAssembly = typeof(ClientProxies.DataServiceBaseClient<>).Assembly;
            builder.RegisterAssemblyTypes(wcfClientAssembly).AsClosedTypesOf(typeof(IDataServiceBase<>)).UseWcfSafeRelease();
            
             */

            // ****************************************************
            // UI configurations
            // ****************************************************
            // Register all types that implement IFormHandler<T> from given assembly
            var formAssembly = Assembly.GetAssembly(typeof(PlantCreateEditModelFormHandler));
            builder.RegisterAssemblyTypes(formAssembly).AsClosedTypesOf(typeof(IFormHandler<>));

            // TEMP: Want to build factory via IoC itself
            builder.RegisterType<AutofacFormHandlerFactory>().As<IFormHandlerFactory>();

            // Register anonymous method that resolves FormHandlers based on type of form that they handle
            // Data service will be injected via registration of types implementing IDataServiceBase<> 
            //builder.Register<Func<IF,IDataServiceBase<IDomainEntity>>>(c => 
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