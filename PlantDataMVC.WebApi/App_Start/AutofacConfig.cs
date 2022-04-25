using Autofac;
using Autofac.Integration.WebApi;
using Framework.Domain.EF;
using Interfaces.Domain.Repository;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using System.Reflection;
using PlantDataMVC.Repository.Interfaces;
using PlantDataMVC.Repository.Repositories;

namespace PlantDataMVC.WebApi
{
    public class AutofacConfig
    {
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //*****************************************
            // Register data context
            // This is passed to UnitOfWork constructor
            //builder.RegisterType<PlantDataDbContext>().As<IPlantDataDbContext>().InstancePerRequest();
            builder.RegisterType<PlantDataDbContext>().As<IDbContext>().InstancePerRequest();

            //*****************************************
            // Register unit of work
            // This is passed to Api controller constructors (and Repository constructors)
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerRequest();

            //*****************************************
            // Register repository types as open generics because they are only closed at call time
            // These are passed to Service constructors
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>));
            builder.RegisterType<GenusRepository>().As<IGenusRepository>();
            builder.RegisterType<JournalEntryRepository>().As<IJournalEntryRepository>();
            builder.RegisterType<JournalEntryTypeRepository>().As<IJournalEntryTypeRepository>();
            builder.RegisterType<ProductTypeRepository>().As<IProductTypeRepository>();
            builder.RegisterType<SeedBatchRepository>().As<ISeedBatchRepository>();
            builder.RegisterType<SiteRepository>().As<ISiteRepository>();
            builder.RegisterType<SpeciesRepository>().As<ISpeciesRepository>();
            builder.RegisterType<SeedTrayRepository>().As<ISeedTrayRepository>();
            builder.RegisterType<SpeciesRepository>().As<ISpeciesRepository>();

            builder.RegisterType<EFRepository<Genus>>().As<IRepositoryAsync<Genus>>();
            builder.RegisterType<EFRepository<JournalEntry>>().As<IRepositoryAsync<JournalEntry>>();
            builder.RegisterType<EFRepository<JournalEntryType>>().As<IRepositoryAsync<JournalEntryType>>();
            builder.RegisterType<EFRepository<ProductType>>().As<IRepositoryAsync<ProductType>>();
            builder.RegisterType<EFRepository<SeedBatch>>().As<IRepositoryAsync<SeedBatch>>();
            builder.RegisterType<EFRepository<Site>>().As<IRepositoryAsync<Site>>();
            builder.RegisterType<EFRepository<Species>>().As<IRepositoryAsync<Species>>();
            builder.RegisterType<EFRepository<SeedTray>>().As<IRepositoryAsync<SeedTray>>();
            builder.RegisterType<EFRepository<PlantStock>>().As<IRepositoryAsync<PlantStock>>();

            //*****************************************
            // Register services wrapping repositories
            // These are passed to API controllers

            builder.RegisterType<GenusService>().As<IGenusService>();
            builder.RegisterType<JournalEntryService>().As<IJournalEntryService>();
            builder.RegisterType<JournalEntryTypeService>().As<IJournalEntryTypeService>();
            builder.RegisterType<ProductTypeService>().As<IProductTypeService>();
            builder.RegisterType<SeedBatchService>().As<ISeedBatchService>();
            builder.RegisterType<SiteService>().As<ISiteService>();
            builder.RegisterType<SpeciesService>().As<ISpeciesService>();
            builder.RegisterType<SeedTrayService>().As<ISeedTrayService>();
            builder.RegisterType<PlantStockService>().As<IPlantStockService>();


            // ****************************************************
            // WebApi configurations
            // ****************************************************

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }

    }
}