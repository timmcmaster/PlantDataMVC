using Framework.Web.DependencyInjection;
using Framework.Web.Forms;
using Framework.Web.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PlantData.Web.Blazor.Services;
using Serilog;
using Syncfusion;
using System;
using System.Linq;
using System.Reflection;

namespace PlantData.Web.Blazor.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Configures IOC services for main domain.
        /// </summary>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // ****************************************************
            // UI configurations
            // ****************************************************

            // Used by QueryDropDown
            Assembly? lookupServicesAssembly = Assembly.GetAssembly(typeof(GenusLookupService));
            services.AddImplementedInterfacesFromAssembly(lookupServicesAssembly, typeof(ILookupService<>));

            // Used in view injections
            services.AddTransient<IGenusLookupService, GenusLookupService>();
            services.AddTransient<IJournalEntryTypeLookupService, JournalEntryTypeLookupService>();
            services.AddTransient<IPriceListTypeLookupService, PriceListTypeLookupService>();
            services.AddTransient<IProductPriceLookupService, ProductPriceLookupService>();
            services.AddTransient<IProductTypeLookupService, ProductTypeLookupService>();
            services.AddTransient<ISaleEventLookupService, SaleEventLookupService>();
            services.AddTransient<ISeedBatchLookupService, SeedBatchLookupService>();
            services.AddTransient<ISeedTrayLookupService, SeedTrayLookupService>();
            services.AddTransient<ISiteLookupService, SiteLookupService>();
            services.AddTransient<ISpeciesLookupService, SpeciesLookupService>();
            services.AddTransient<IBarcodeLayoutLookupService, BarcodeLayoutLookupService>();

            /// Extensions to scan for MediatR handlers and registers them.
            /// - Scans for any handler interface implementations and registers them as <see cref="ServiceLifetime.Transient"/>
            /// - Scans for any <see cref="IRequestPreProcessor{TRequest}"/> and <see cref="IRequestPostProcessor{TRequest,TResponse}"/> implementations and registers them as transient instances
            /// Registers <see cref="ServiceFactory"/> and <see cref="IMediator"/> as transient instances
            /// After calling AddMediatR you can use the container to resolve an <see cref="IMediator"/> instance.
            /// This does not scan for any <see cref="IPipelineBehavior{TRequest,TResponse}"/> instances including <see cref="RequestPreProcessorBehavior{TRequest,TResponse}"/> and <see cref="RequestPreProcessorBehavior{TRequest,TResponse}"/>.
            /// To register behaviors, use the <see cref="ServiceCollectionServiceExtensions.AddTransient(IServiceCollection,Type,Type)"/> with the open generic or closed generic types.            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Startup>());

            // Before we leave this method, write our registrations to log file
            services.LogRegisteredServices(Log.Logger);

            return services;
        }

        public static IServiceCollection AddViewModelsAndInterfaces(this IServiceCollection services)
        {
            string assemblyNamePrefix = "PlantData.Web.Blazor.ViewModels";
            string vmNamespacePrefix = "PlantData.Web.Blazor.ViewModels";
            string vmNameSuffix = "ViewModel";

            var assembly = AppDomain.CurrentDomain.GetAssemblies()
               .Where(a => a.FullName!.StartsWith(assemblyNamePrefix, StringComparison.InvariantCulture))
               .First();

            var classes = assembly.ExportedTypes
               .Where(a => a.FullName!.EndsWith(vmNameSuffix, StringComparison.InvariantCulture) &&
                           a.Namespace!.StartsWith(vmNamespacePrefix, StringComparison.InvariantCulture));

            foreach (Type t in classes)
            {
                foreach (Type i in t.GetInterfaces())
                {
                    if ($"I{t.Name}" == i.Name)
                        services.AddTransient(i, t);
                }
            }

            // Before we leave this method, write our registrations to log file
            services.LogRegisteredServices(Log.Logger);
            return services;
        }
    }
}