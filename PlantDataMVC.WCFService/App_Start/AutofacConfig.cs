using Autofac;
using Autofac.Integration.Wcf;
using Framework.DAL.EF;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service;
using PlantDataMVC.Service.SimpleServiceLayer;
using System.Reflection;

namespace PlantDataMVC.WCFService
{
    public class AutofacConfig
    {
        // TODO: Not sure if we really need this config here.
        // If we can take it out, we can remove specific reference to Framework.DAL.EF
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register your service implementations. 
            //builder.RegisterType<PlantDataService>();
            //builder.RegisterType<PlantSeedDataService>();
            var svcAssembly = Assembly.GetAssembly(typeof(PlantDataService));
            builder.RegisterAssemblyTypes(svcAssembly)
                .AsClosedTypesOf(typeof(IBasicDataService<>));

            // Register direct dependencies
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();

            // Set the dependency resolver. This works for both regular
            // WCF services and REST-enabled services.
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }

    }
}