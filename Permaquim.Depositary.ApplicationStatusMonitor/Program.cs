using Serilog;
using Serilog.Events;
using Permaquim.Depositary.ApplicationStatusMonitor;

Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Debug()
     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
     .Enrich.FromLogContext()
     .WriteTo.File(@"C:\temp\LogFile.txt")
     .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

