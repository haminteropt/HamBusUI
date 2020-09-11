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
    public List<BusConfigurationDB>? BusDbConfig { get; set; }
    void UpdateState(RigState state);
    void UpdateActiveBuses(ActiveBusesModel bus);
    void UpdateFromInfoPacket(UiInfoPacketModel infoList);
    void UpdateBusConfig(BusConfigurationDB bus);
    BusConfigurationDB? FindByName(string name);

  }
}
