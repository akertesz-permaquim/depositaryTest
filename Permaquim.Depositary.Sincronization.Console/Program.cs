using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Permaquim.Depositary.Sincronization.Console;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Debug()
     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
     .Enrich.FromLogContext()
     .WriteTo.File(@"C:\temp\LogFile.txt")
     .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();