using Autofac;
using Autofac.Integration.Wcf;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
//using Interfaces.DAL.Repository;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Service.SimpleServiceLayer;
using System.Reflection;

namespace PlantDataMVC.WCFService
{
    public class AutofacConfig
    {
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        public static void ConfigureContainer()
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

            // Register your service implementations (for injection into WCF *.svc definitions)
            var svcAssembly = Assembly.GetAssembly(typeof(PlantDataService));
            builder.RegisterAssemblyTypes(svcAssembly).AsClosedTypesOf(typeof(IBasicDataService<>));

            // Set the dependency resolver. This works for both regular
            // WCF services and REST-enabled services.
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }

    }
}