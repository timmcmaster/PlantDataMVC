using Serilog;
using Serilog.Events;

namespace PlantData.Web.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.Console()
                .WriteTo.File("..\\logs\\Blazor-bootstrap-log-.txt",
                    rollingInterval: RollingInterval.Day)
                .CreateBootstrapLogger();


            Log.Information("Starting up");

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }
            finally
            {
                Log.Information("Shut down complete");
                Log.CloseAndFlush();
            }


            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            //builder.Services.AddRazorComponents()
            //    .AddInteractiveServerComponents();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, loggerConfig) =>
                {
                    loggerConfig.ReadFrom.Configuration(context.Configuration);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
