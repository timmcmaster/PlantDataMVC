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
        public static IContainer ConfigureContainer()
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
            //builder.RegisterType<PlantDataDbContext>().As<IDataContextAsync>();

            //builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();

            // ****************************************************
            // Core configurations
            // ****************************************************

            // Register services from PlantDataMVC.Service assembly.
            // i.e. when running assembly in same application
            //var svcAssembly = typeof(PlantDataService).Assembly;
            //builder.RegisterAssemblyTypes(svcAssembly).AsClosedTypesOf(typeof(IDataServiceBase<>));

            // Required service is now IPlantDataService instead of IDataServiceBase<Plant>
            // Register specific services for now
            //builder.RegisterType<PlantDataService>().As<IPlantDataService>();
            //builder.RegisterType<PlantProductTypeDataService>().As<IPlantProductTypeDataService>();
            //builder.RegisterType<PlantSeedDataService>().As<IPlantSeedDataService>();
            //builder.RegisterType<PlantSeedSiteDataService>().As<IPlantSeedSiteDataService>();
            //builder.RegisterType<PlantSeedTrayDataService>().As<IPlantSeedTrayDataService>();
            //builder.RegisterType<PlantStockEntryDataService>().As<IPlantStockEntryDataService>();
            //builder.RegisterType<PlantStockTransactionDataService>().As<IPlantStockTransactionDataService>();
            //builder.RegisterType<PlantStockTransactionTypeDataService>().As<IPlantStockTransactionTypeDataService>();

            // ****************************************************
            // WCF Service configurations
            // ****************************************************

            //* TODO: Fix registration of WCF services

            // Register channel factory (for all service interfaces, based on Web.config definitions)
            builder.Register(c => new ChannelFactory<IPlantDataService>("BasicHttpBinding_IPlantDataService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantProductTypeDataService>("BasicHttpBinding_IPlantProductTypeDataService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantSeedDataService>("BasicHttpBinding_IPlantSeedDataService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantSeedSiteDataService>("BasicHttpBinding_IPlantSeedSiteDataService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantSeedTrayDataService>("BasicHttpBinding_IPlantSeedTrayDataService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantStockEntryDataService>("BasicHttpBinding_IPlantStockEntryDataService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantStockTransactionDataService>("BasicHttpBinding_IPlantStockTransactionDataService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantStockTransactionTypeDataService>("BasicHttpBinding_IPlantStockTransactionTypeDataService"))
                .SingleInstance();

            // Register the service interface using a lambda that creates a channel from the factory. 
            // Include the UseWcfSafeRelease() helper to handle proper disposal.
            builder.Register(c => c.Resolve<ChannelFactory<IPlantDataService>>().CreateChannel())
              .As<IPlantDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantProductTypeDataService>>().CreateChannel())
              .As<IPlantProductTypeDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantSeedDataService>>().CreateChannel())
              .As<IPlantSeedDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantSeedSiteDataService>>().CreateChannel())
              .As<IPlantSeedSiteDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantSeedTrayDataService>>().CreateChannel())
              .As<IPlantSeedTrayDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantStockEntryDataService>>().CreateChannel())
              .As<IPlantStockEntryDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantStockTransactionDataService>>().CreateChannel())
              .As<IPlantStockTransactionDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantStockTransactionTypeDataService>>().CreateChannel())
              .As<IPlantStockTransactionTypeDataService>()
              .UseWcfSafeRelease();
            //*/

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

            return builder.Build();
        }
    }
}