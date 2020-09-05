using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorBus.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BlazorBus
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);

      builder.Services.AddSingleton<IBusStatusService, BusStatusService>();
      builder.Services.AddSingleton<IHamSignalRService, HamSignalRService>();
      builder.Services.AddSingleton<IActiveBusesService, ActiveBusesService>();

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
      );

      Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.BrowserConsole().CreateLogger();
      builder.RootComponents.Add<App>("app");
      await builder.Build().RunAsync();
    }
  }
}
