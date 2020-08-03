﻿using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BlazorBus.SharedModels;
using HamBusCommmonStd;
using HamBusCommonStd;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorBus.Services
{
  public class HamSignalRService : IHamSignalRService
  {
    #region Observables 
    public Subject<UiInfoPacketModel> InfoPacket__ { get; set; } = new Subject<UiInfoPacketModel>();
    public Subject<RigState> RigState__ { get; set; } = new Subject<RigState>();

    public BehaviorSubject<HamBusError> HBErrors__ { get; set; } = new BehaviorSubject<HamBusError>(null);
    public Subject<HamBusError> SaveResults { get; set; } = new Subject<HamBusError>();
    #endregion

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
      connection.On<HamBusError>("ErrorReport", (errorReport) => HBErrors__.OnNext(errorReport));
      connection.On<UiInfoPacketModel>("InfoPacket", (info) =>
      {
        InfoPacket__.OnNext(info);
      });
      connection.On<RigState>("state", (state) =>
      {
        RigState__.OnNext(state);
      });
    }
  }
}
