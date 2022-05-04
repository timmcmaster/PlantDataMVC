﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlantDataMVC.Constants;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.DependencyInjection;
using PlantDataMVC.UICore.Helpers;
using System;
using System.Net.Http.Headers;
//using Microsoft.AspNetCore.Mvc.Versioning;

namespace PlantDataMVC.UICore
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            // In ASP.NET Core 3.x, using `Host.CreateDefaultBuilder` (as in the preceding Program.cs snippet) will
            // set up some configuration for you based on your appsettings.json and environment variables. See "Remarks" at
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder for details.
            this.Configuration = configuration;
        }

        // ConfigureServices is where you register dependencies.
        public void ConfigureServices(IServiceCollection services)
        {
            // Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicies.RequireReadUserRole, policy =>
                {
                    policy.RequireRole(AuthorizationRole.WebReadUser);
                });
                options.AddPolicy(AuthorizationPolicies.RequireWriteUserRole, policy =>
                {
                    policy.RequireRole(AuthorizationRole.WebWriteUser);
                });
                options.AddPolicy(AuthorizationPolicies.RequireAdminUserRole, policy =>
                {
                    policy.RequireRole(AuthorizationRole.WebAdminUser);
                });
            });

            // HttpClientFactory
            // -->
            services.AddTransient<TokenMessageHandler>();

            services.AddHttpClient(NamedHttpClients.PlantDataApi, client =>
            {
                client.BaseAddress = new Uri(PlantDataMvcConstants.PlantDataApi);

                // clear the accept headers and set those we require for ALL client requests
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddHttpMessageHandler<TokenMessageHandler>();
            // <--

            // Main Domain stuff
            services.AddDomainServices();

            // MVC
            services.AddControllersWithViews();
        }


        // Configure is where you add middleware.        
        // You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}