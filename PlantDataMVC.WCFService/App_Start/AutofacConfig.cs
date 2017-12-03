using Autofac;
using Autofac.Integration.Wcf;
using Framework.DAL.EF;
using Framework.DAL.UnitOfWork;
using Framework.Service.ServiceLayer;
using PlantDataMVC.Service.SimpleServiceLayer;
using System.Reflection;

namespace PlantDataMVC.WCFService
{
    public class AutofacConfig
    {
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