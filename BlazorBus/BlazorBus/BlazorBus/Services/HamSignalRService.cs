using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamBusBlazorLibrary.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using BlazorBus.SharedModels;

namespace BlazorBus.Services
{
  public class HamSignalRService : IHamSignalRService
  {

    public Subject<UiInfoPacketModel> InfoPacket__ { get; set; } = new Subject<UiInfoPacketModel>();
    public Subject<HamBusError> HBErrors__ { get; set; } = new Subject<HamBusError>();

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
        BuildResponseActions();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Environment.Exit(-1);
      }

      return connection;
    }

    private void BuildResponseActions()
    {
      connection.On<HamBusError>("ErrorReport", (errorReport) =>
      {
        HBErrors__.OnNext(errorReport);
      });
    }
  }
}
