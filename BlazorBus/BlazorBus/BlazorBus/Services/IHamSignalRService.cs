using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BlazorBus.SharedModels;
using HamBusCommonStd;
using Microsoft.AspNetCore.SignalR.Client;


namespace BlazorBus.Services
{
  public interface IHamSignalRService
  {
    Subject<UiInfoPacketModel> InfoPacket__ { get; set; }
    Subject<RigState> RigState__ { get; set; }
    BehaviorSubject<HamBusError> HBErrors__ { get; set; }
    Subject<HamBusError> SaveResults__ { get; set; }
    Subject<ActiveBusesModel> ActiveUpdate__ { get; set; }
    Task<HubConnection> StartService(string url);
    Task Login(List<string> groupList, string name);
    Task SetLock(LockModel locker);
  }
}
