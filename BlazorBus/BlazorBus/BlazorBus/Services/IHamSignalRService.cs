using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BlazorBus.SharedModels;
using Microsoft.AspNetCore.SignalR.Client;


namespace BlazorBus.Services
{
  public interface IHamSignalRService
  {
    //ReplaySubject<UiInfoPacketModel> InfoPacket__ { get; set; }
    //ReplaySubject<RigState> RigState__ { get; set; }
    //BehaviorSubject<HamBusError> HBErrors__ { get; set; }
    //Subject<HamBusError> SaveResults { get; set; }

    Task<HubConnection> StartService(string url);
  }
}
