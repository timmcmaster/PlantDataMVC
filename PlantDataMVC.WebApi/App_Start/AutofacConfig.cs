using Autofac;
using Autofac.Integration.WebApi;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.Repository;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using System.Reflection;

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
            builder.RegisterType<PlantDataDbContext>().As<IDataContextAsync>().InstancePerRequest();

            //*****************************************
            // Register unit of work
            // This is passed to Api controller constructors (and Repository constructors)
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerRequest();

            //*****************************************
            // Register repository types as open generics because they are only closed at call time
            // These are passed to Service constructors
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>));

            builder.RegisterType<Repository<Genus>>().As<IRepositoryAsync<Genus>>();
            builder.RegisterType<Repository<JournalEntry>>().As<IRepositoryAsync<JournalEntry>>();
            //builder.RegisterType<Repository<JournalEntryType>>().As<IRepositoryAsync<JournalEntryType>>();
            //builder.RegisterType<Repository<ProductType>>().As<IRepositoryAsync<ProductType>>();
            builder.RegisterType<Repository<SeedBatch>>().As<IRepositoryAsync<SeedBatch>>();
            builder.RegisterType<Repository<Site>>().As<IRepositoryAsync<Site>>();
            builder.RegisterType<Repository<Species>>().As<IRepositoryAsync<Species>>();
            builder.RegisterType<Repository<SeedTray>>().As<IRepositoryAsync<SeedTray>>();
            builder.RegisterType<Repository<PlantStock>>().As<IRepositoryAsync<PlantStock>>();

            //*****************************************
            // Register services wrapping repositories
            // These are passed to API controllers

            builder.RegisterType<GenusService>().As<IGenusService>();
            builder.RegisterType<JournalEntryService>().As<IJournalEntryService>();
            //builder.RegisterType<JournalEntryTypeService>().As<IJournalEntryTypeService>();
            //builder.RegisterType<ProductTypeService>().As<IProductTypeService>();
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