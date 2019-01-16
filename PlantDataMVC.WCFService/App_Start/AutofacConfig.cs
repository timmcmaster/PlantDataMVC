using Autofac;
using Common.Logging;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
//using Interfaces.DAL.Repository;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service;
using Interfaces.WCFService;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;
using PlantDataMVC.WCFService.Services;
using System.Reflection;

namespace PlantDataMVC.WCFService
{
    public class AutofacConfig
    {
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // ****************************************************
            // DAL configurations
            // ****************************************************
            builder.RegisterType<PlantDataDbContext>().As<IDataContextAsync>();
            
            // Register repository types for now (used via ServiceLocator in UoW)
            // TODO: Make factory instead, manage lifetime scope
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>));

            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();

            // Register services wrapping repositories as (for example) IGenusService and IService<Genus>
            var svcAssembly = Assembly.GetAssembly(typeof(GenusService));
            builder.RegisterAssemblyTypes(svcAssembly)
                    .Where(t => t.IsClosedTypeOf(typeof(IWcfService<>)))
                    .AsImplementedInterfaces();

            // Register your service implementations (for injection into WCF *.svc definitions)
            //var svcAssembly = Assembly.GetAssembly(typeof(PlantDataService));
            //builder.RegisterAssemblyTypes(svcAssembly).AsClosedTypesOf(typeof(IDataServiceBase<>));

            // Required service is now I*WcfService
            // Register specific services for now
            //builder.RegisterType<PlantDataService>().As<IPlantDataService>();

            // Register services for WCF
            builder.RegisterType<GenusWcfService>().As<IGenusWcfService>();
            builder.RegisterType<JournalEntryWcfService>().As<IJournalEntryWcfService>();
            builder.RegisterType<JournalEntryTypeWcfService>().As<IJournalEntryTypeWcfService>();
            builder.RegisterType<ProductTypeWcfService>().As<IProductTypeWcfService>();
            builder.RegisterType<SeedBatchWcfService>().As<ISeedBatchWcfService>();
            builder.RegisterType<SiteWcfService>().As<ISiteWcfService>();
            builder.RegisterType<SpeciesWcfService>().As<ISpeciesWcfService>();
            builder.RegisterType<SeedTrayWcfService>().As<ISeedTrayWcfService>();
            builder.RegisterType<PlantStockWcfService>().As<IPlantStockWcfService>();

            // Register singleton instance of ILog for Common.Logging
            // TODO: This is a bit dodgy, as it doesn't allow us to use NLog rules based on logging class.
            //builder.RegisterInstance(LogManager.GetLogger("PlantDataMVC.WCFServices")).As<ILog>();

            // Set the dependency resolver. This works for both regular
            // WCF services and REST-enabled services.
            return builder.Build();
        }

    }
}