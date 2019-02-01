using Autofac;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.WCFService.ServiceContracts;
using PlantDataMVC.WCFService.Services;
//using Interfaces.DAL.Repository;
//using PlantDataMVC.Entities.Models;
//using PlantDataMVC.Service;

namespace PlantDataMVC.WCFService
{
    public class AutofacConfig
    {
        /// <summary>
        ///     Configures and builds Autofac IOC container.
        /// </summary>
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //*****************************************
            // Register data context
            // This is passed to UnitOfWork constructor
            builder.RegisterType<PlantDataDbContext>().As<IDataContextAsync>();

            //*****************************************
            // Register unit of work
            // This is passed to WcfService constructors (and Repository constructors)
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();

            //*****************************************
            // Register repository types as open generics because they are only closed at call time
            // These are passed to Service constructors
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>));

            //builder.RegisterType<Repository<Genus>>().As<IRepositoryAsync<Genus>>();
            //builder.RegisterType<Repository<JournalEntry>>().As<IRepositoryAsync<JournalEntry>>();
            //builder.RegisterType<Repository<JournalEntryType>>().As<IRepositoryAsync<JournalEntryType>>();
            //builder.RegisterType<Repository<ProductType>>().As<IRepositoryAsync<ProductType>>();
            //builder.RegisterType<Repository<SeedBatch>>().As<IRepositoryAsync<SeedBatch>>();
            //builder.RegisterType<Repository<Site>>().As<IRepositoryAsync<Site>>();
            //builder.RegisterType<Repository<Species>>().As<IRepositoryAsync<Species>>();
            //builder.RegisterType<Repository<SeedTray>>().As<IRepositoryAsync<SeedTray>>();
            //builder.RegisterType<Repository<PlantStock>>().As<IRepositoryAsync<PlantStock>>();

            //*****************************************
            // Register services wrapping repositories
            // These are not currently used anywhere

            //var svcAssembly = Assembly.GetAssembly(typeof(GenusService));
            //builder.RegisterAssemblyTypes(svcAssembly).AsClosedTypesOf(typeof(IService<>)).AsImplementedInterfaces();

            //builder.RegisterType<GenusService>().As<IGenusService>();
            //builder.RegisterType<JournalEntryService>().As<IJournalEntryService>();
            //builder.RegisterType<JournalEntryTypeService>().As<IJournalEntryTypeService>();
            //builder.RegisterType<ProductTypeService>().As<IProductTypeService>();
            //builder.RegisterType<SeedBatchService>().As<ISeedBatchService>();
            //builder.RegisterType<SiteService>().As<ISiteService>();
            //builder.RegisterType<SpeciesService>().As<ISpeciesService>();
            //builder.RegisterType<SeedTrayService>().As<ISeedTrayService>();
            //builder.RegisterType<PlantStockService>().As<IPlantStockService>();


            //*****************************************
            // Register services for WCF
            // These are "passed" to WCF .svc files via WCF injection
            builder.RegisterType<GenusWcfService>().As<IGenusWcfService>();
            builder.RegisterType<JournalEntryWcfService>().As<IJournalEntryWcfService>();
            builder.RegisterType<JournalEntryTypeWcfService>().As<IJournalEntryTypeWcfService>();
            builder.RegisterType<ProductTypeWcfService>().As<IProductTypeWcfService>();
            builder.RegisterType<SeedBatchWcfService>().As<ISeedBatchWcfService>();
            builder.RegisterType<SiteWcfService>().As<ISiteWcfService>();
            builder.RegisterType<SpeciesWcfService>().As<ISpeciesWcfService>();
            builder.RegisterType<SeedTrayWcfService>().As<ISeedTrayWcfService>();
            builder.RegisterType<PlantStockWcfService>().As<IPlantStockWcfService>();

            return builder.Build();
        }
    }
}