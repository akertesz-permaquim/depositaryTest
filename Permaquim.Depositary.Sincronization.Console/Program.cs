using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Permaquim.Depositary.Sincronization.Console;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

    })
    .Build();

//Utilizamos mutex para no permitir que se ejecute mas de una instancia del servicio a la vez.
var mutex = new Mutex(false, Assembly.GetEntryAssembly().GetName().Name);
if (mutex.WaitOne(TimeSpan.Zero, true))
{
    host.Run();

    mutex.ReleaseMutex();
    mutex.Dispose();
}



