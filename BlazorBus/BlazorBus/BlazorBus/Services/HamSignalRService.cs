﻿using System;
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
    //#region Observibles 
    //public ReplaySubject<UiInfoPacketModel> InfoPacket__ { get; set; } = new ReplaySubject<UiInfoPacketModel>(1);
    //public ReplaySubject<RigState> RigState__ { get; set; } = new ReplaySubject<RigState>(1);

    //public BehaviorSubject<HamBusError> HBErrors__ { get; set; } = new BehaviorSubject<HamBusError>(null);
    //public Subject<HamBusError> SaveResults { get; set; } = new Subject<HamBusError>();
    //#endregion

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
      //  connection.On<HamBusError>("ErrorReport", (errorReport) => HBErrors__.OnNext(errorReport));
      //connection.On<UiInfoPacketModel>("ErrorReport", (info) => InfoPacket__.OnNext(info));
      //  connection.On<RigState>("ErrorReport", (info) => RigState__.OnNext(info));
    }
    }
}
