using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamBusCommonStd;

namespace BlazorBus.Services
{
  public interface IBusStatusService
  {
    List<BusStatusModel> BusStatusList { get; set; }
    void UpdateState(RigState state);
    void UpdateActiveBuses(ActiveBusesModel bus);
    void UpdateFromInfoPacket(UiInfoPacketModel infoList);

  }
}
