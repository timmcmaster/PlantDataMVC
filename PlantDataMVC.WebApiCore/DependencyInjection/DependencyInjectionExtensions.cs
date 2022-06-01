using Framework.Domain.EF;
using Framework.Web.Core.DependencyInjection;
using Interfaces.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Repository.Interfaces;
using PlantDataMVC.Repository.Repositories;
using PlantDataMVC.Service;
using Serilog;

namespace PlantDataMVC.WebApiCore.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Configures IOC services for main domain.
        /// </summary>
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration config)
        {
            //*****************************************
            // Register data context
            // This is passed to UnitOfWork constructor
            //services.AddScoped<IDbContext, PlantDataDbContext>();
            services.AddDbContext<PlantDataDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("PlantDataDbContext"));
                options.AddInterceptors(new EfLoggingInterceptor());

            });
            services.AddScoped<IDbContext>(provider => provider.GetService<PlantDataDbContext>());

            //*****************************************
            // Register unit of work
            // This is passed to Api controller constructors (and Repository constructors)
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();

            //*****************************************
            // Register repository types as open generics because they are only closed at call time
            // These are passed to Service constructors

            services.AddTransient<IGenusRepository, GenusRepository>();
            services.AddTransient<IJournalEntryRepository, JournalEntryRepository>();
            services.AddTransient<IJournalEntryTypeRepository, JournalEntryTypeRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<ISeedBatchRepository, SeedBatchRepository>();
            services.AddTransient<ISiteRepository, SiteRepository>();
            services.AddTransient<ISpeciesRepository, SpeciesRepository>();
            services.AddTransient<ISeedTrayRepository, SeedTrayRepository>();
            services.AddTransient<ISpeciesRepository, SpeciesRepository>();
            services.AddTransient<IPlantStockRepository, PlantStockRepository>();
            services.AddTransient<ISaleEventRepository, SaleEventRepository>();

            //*****************************************
            // Register services wrapping repositories
            // These are passed to API controllers
            services.AddTransient<IGenusService, GenusService>();
            services.AddTransient<IJournalEntryService, JournalEntryService>();
            services.AddTransient<IJournalEntryTypeService, JournalEntryTypeService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<ISeedBatchService, SeedBatchService>();
            services.AddTransient<ISiteService, SiteService>();
            services.AddTransient<ISpeciesService, SpeciesService>();
            services.AddTransient<ISeedTrayService, SeedTrayService>();
            services.AddTransient<IPlantStockService, PlantStockService>();
            services.AddTransient<ISaleEventService, SaleEventService>();

            // Before we leave this method, write our registrations to log file
            services.LogRegisteredServices(Log.Logger);

            return services;
        }

    }
}