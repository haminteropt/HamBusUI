using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamBusBlazorLibrary.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorBus.Services
{
  public class HamSignalRService : IHamSignalRService
  {
    private HubConnection connection;
    public HamSignalRService()
    {

    }
    public async Task<HubConnection> StartService(string url)
    {
      connection = new HubConnectionBuilder()
          .WithUrl(url)
          .Build();

      connection.Closed += async (error) =>
      {
        await Task.Delay(new Random().Next(0, 5) * 1000);
        await connection.StartAsync();
      };
      connection.Reconnecting += error =>
      {
        Console.WriteLine($"Connection Lost attempting to reconnect: {error.Message}");

        // Notify users the connection was lost and the client is reconnecting.
        // Start queuing or dropping messages.

        return Task.CompletedTask;
      };
      try
      {
        await connection.StartAsync();
        //connection.On<HamBusError>("ErrorReport", ErrorReport);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Environment.Exit(-1);
      }

      return connection;
    }
  }
}
