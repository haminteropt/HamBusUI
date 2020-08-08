using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorBus.SharedModels;
using HamBusCommonStd;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorBus.Services
{
  public class HamSignalRService : IHamSignalRService
  {
    [Inject]
    private ActiveBusesService ActiveBuses { get; set; }

    //[Inject]
    private IBusStatusService BusService { get; set; }
    #region Observables 
    public Subject<ActiveBusesModel> ActiveUpdate__ { get; set; } = new Subject<ActiveBusesModel>();
    public Subject<UiInfoPacketModel> InfoPacket__ { get; set; } = new Subject<UiInfoPacketModel>();
    public Subject<RigState> RigState__ { get; set; } = new Subject<RigState>();
    public BehaviorSubject<HamBusError> HBErrors__ { get; set; } = new BehaviorSubject<HamBusError>(null);
    public Subject<HamBusError> SaveResults__ { get; set; } = new Subject<HamBusError>();
    #endregion

    JsonSerializerOptions options = new JsonSerializerOptions
    {
      //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = true
    };

    private HubConnection connection;
    public HamSignalRService(IBusStatusService bs)
    {
      BusService = bs; 
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
      connection.On<HamBusError>(SignalRCommands.ErrorReport, (errorReport) => HBErrors__.OnNext(errorReport));
      connection.On<UiInfoPacketModel>(SignalRCommands.InfoPacket, (info) =>
      {
        BusService.UpdateFromInfoPacket(info);

        InfoPacket__.OnNext(info);
      });
      connection.On<RigState>(SignalRCommands.State, (state) =>
      {
        BusService.UpdateState(state);
        RigState__.OnNext(state);
      });
      connection.On<ActiveBusesModel>(SignalRCommands.ActiveUpdate, (update) =>
      {
        BusService.UpdateActiveBuses(update);
        ActiveUpdate__.OnNext(update);
      });
    }
  }
}
