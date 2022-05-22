using Framework.Domain.EF;
using Interfaces.Domain.Repository;
using Interfaces.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using PlantDataMVC.Repository.Repositories;
using PlantDataMVC.Service;

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
            });
            services.AddScoped<IDbContext>(provider => provider.GetService<PlantDataDbContext>());

            //*****************************************
            // Register unit of work
            // This is passed to Api controller constructors (and Repository constructors)
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();

            //*****************************************
            // Register repository types as open generics because they are only closed at call time
            // These are passed to Service constructors
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>));

            // TODO: Work out which repository style to use, also check scopes
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

            return services;
        }

    }
}