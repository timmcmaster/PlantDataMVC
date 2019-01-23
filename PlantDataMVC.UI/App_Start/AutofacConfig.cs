using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using Framework.Web.Forms;
using PlantDataMVC.UI.Forms;
using PlantDataMVC.UI.Forms.Handlers;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Reflection;
using System.ServiceModel;

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
            // WCF SOAP Service configurations
            // ****************************************************

            // Register channel factory (for all service interfaces, based on Web.config definitions)
            builder.Register(c => new ChannelFactory<IGenusWcfService>("BasicHttpBinding_IGenusWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<ISpeciesWcfService>("BasicHttpBinding_ISpeciesWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IProductTypeWcfService>("BasicHttpBinding_IProductTypeWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<ISeedBatchWcfService>("BasicHttpBinding_ISeedBatchWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<ISiteWcfService>("BasicHttpBinding_ISiteWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<ISeedTrayWcfService>("BasicHttpBinding_ISeedTrayWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IPlantStockWcfService>("BasicHttpBinding_IPlantStockWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IJournalEntryWcfService>("BasicHttpBinding_IJournalEntryWcfService"))
                .SingleInstance();
            builder.Register(c => new ChannelFactory<IJournalEntryTypeWcfService>("BasicHttpBinding_IJournalEntryTypeWcfService"))
                .SingleInstance();

            // Register the service interface using a lambda that creates a channel from the factory. 
            // Include the UseWcfSafeRelease() helper to handle proper disposal.
            builder.Register(c => c.Resolve<ChannelFactory<IGenusWcfService>>().CreateChannel())
              .As<IGenusWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<ISpeciesWcfService>>().CreateChannel())
              .As<ISpeciesWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IProductTypeWcfService>>().CreateChannel())
              .As<IProductTypeWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<ISeedBatchWcfService>>().CreateChannel())
              .As<ISeedBatchWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<ISiteWcfService>>().CreateChannel())
              .As<ISiteWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<ISeedTrayWcfService>>().CreateChannel())
              .As<ISeedTrayWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IPlantStockWcfService>>().CreateChannel())
              .As<IPlantStockWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IJournalEntryWcfService>>().CreateChannel())
              .As<IJournalEntryWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<ChannelFactory<IJournalEntryTypeWcfService>>().CreateChannel())
              .As<IJournalEntryTypeWcfService>()
              .UseWcfSafeRelease();

            /*
            // ****************************************************
            // WCF JSON Service configurations
            // ****************************************************

            // Register channel factory (for all service interfaces, based on Web.config definitions)
            builder.Register(c => new WebChannelFactory<IPlantDataService>("WebHttpBinding_IPlantDataService"))
                .SingleInstance();
            builder.Register(c => new WebChannelFactory<IProductTypeWcfService>("WebHttpBinding_IProductTypeWcfService"))
                .SingleInstance();
            builder.Register(c => new WebChannelFactory<ISeedBatchWcfService>("WebHttpBinding_ISeedBatchWcfService"))
                .SingleInstance();
            builder.Register(c => new WebChannelFactory<ISiteWcfService>("WebHttpBinding_ISiteWcfService"))
                .SingleInstance();
            builder.Register(c => new WebChannelFactory<ISeedTrayWcfService>("WebHttpBinding_ISeedTrayWcfService"))
                .SingleInstance();
            builder.Register(c => new WebChannelFactory<IPlantStockWcfService>("WebHttpBinding_IPlantStockWcfService"))
                .SingleInstance();
            builder.Register(c => new WebChannelFactory<IJournalEntryWcfService>("WebHttpBinding_IJournalEntryWcfService"))
                .SingleInstance();
            builder.Register(c => new WebChannelFactory<IJournalEntryTypeWcfService>("WebHttpBinding_IJournalEntryTypeWcfService"))
                .SingleInstance();

            // Register the service interface using a lambda that creates a channel from the factory. 
            // Include the UseWcfSafeRelease() helper to handle proper disposal.
            builder.Register(c => c.Resolve<WebChannelFactory<IPlantDataService>>().CreateChannel())
              .As<IPlantDataService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<WebChannelFactory<IProductTypeWcfService>>().CreateChannel())
              .As<IProductTypeWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<WebChannelFactory<ISeedBatchWcfService>>().CreateChannel())
              .As<ISeedBatchWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<WebChannelFactory<ISiteWcfService>>().CreateChannel())
              .As<ISiteWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<WebChannelFactory<ISeedTrayWcfService>>().CreateChannel())
              .As<ISeedTrayWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<WebChannelFactory<IPlantStockWcfService>>().CreateChannel())
              .As<IPlantStockWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<WebChannelFactory<IJournalEntryWcfService>>().CreateChannel())
              .As<IJournalEntryWcfService>()
              .UseWcfSafeRelease();
            builder.Register(c => c.Resolve<WebChannelFactory<IJournalEntryTypeWcfService>>().CreateChannel())
              .As<IJournalEntryTypeWcfService>()
              .UseWcfSafeRelease();
            */  

            // ****************************************************
            // UI configurations
            // ****************************************************
            // Register all types that implement IFormHandler<T> from given assembly
            Assembly formAssembly = Assembly.GetAssembly(typeof(PlantCreateEditModelFormHandler));
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