using Microsoft.AspNetCore.Builder;
using PlantDataMVC.IdentityServer;
using Serilog;
using System;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("..\\logs\\IdentityServer-bootstrap-log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .WriteTo.File("..\\logs\\IdentityServer-log-.txt",
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext} {Message:lj} {Exception}{NewLine}",
            rollingInterval: RollingInterval.Day)
    );

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    app.Run();
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