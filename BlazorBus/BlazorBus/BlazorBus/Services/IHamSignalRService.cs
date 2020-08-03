﻿using System.Reactive.Subjects;
using System.Threading.Tasks;
using BlazorBus.SharedModels;
using HamBusCommmonStd;
using HamBusCommonStd;
using Microsoft.AspNetCore.SignalR.Client;


namespace BlazorBus.Services
{
  public interface IHamSignalRService
  {
    Subject<UiInfoPacketModel> InfoPacket__ { get; set; }
    Subject<RigState> RigState__ { get; set; }
    BehaviorSubject<HamBusError> HBErrors__ { get; set; }
    Subject<HamBusError> SaveResults { get; set; }

    Task<HubConnection> StartService(string url);
  }
}
