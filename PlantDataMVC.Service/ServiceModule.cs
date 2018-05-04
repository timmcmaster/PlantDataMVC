using Autofac;
using Interfaces.Service;
using PlantDataMVC.Service.SimpleServiceLayer;

namespace PlantDataMVC.Service
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // 0. Register entire service layer object
            // builder.RegisterType<SimpleServiceLayer>().As<IServiceLayer>();

            // OR 1. Register all types that implement IBasicDataService<T> from given assembly
            var svcAssembly = typeof(PlantDataService).Assembly;
            builder.RegisterAssemblyTypes(svcAssembly)
                .AsClosedTypesOf(typeof(IBasicDataService<>));

            // OR 2. Alternatively, register all individual services
            //builder.RegisterType<PlantDataService>().As<IBasicDataService<Plant>>();
            //builder.RegisterType<PlantProductTypeDataService>().As<IBasicDataService<PlantProductType>>();
            //builder.RegisterType<PlantSeedDataService>().As<IBasicDataService<PlantSeed>>();
            //builder.RegisterType<PlantSeedSiteDataService>().As<IBasicDataService<PlantSeedSite>>();
            //builder.RegisterType<PlantSeedTrayDataService>().As<IBasicDataService<PlantSeedTray>>();
            //builder.RegisterType<PlantStockEntryDataService>().As<IBasicDataService<PlantStockEntry>>();
            //builder.RegisterType<PlantStockTransactionDataService>().As<IBasicDataService<PlantStockTransaction>>();
            //builder.RegisterType<PlantStockTransactionTypeDataService>().As<IBasicDataService<PlantStockTransactionType>>();

            // Or 3. Register component as factory
            //builder.Register<Func<IDomainEntity,IBasicDataService<IDomainEntity>>>(c => 
            //{
            //    var cc = c.Resolve<IComponentContext>();
            //    return ds => cc.Resolve<T>();
            //});
        }
    }
}
