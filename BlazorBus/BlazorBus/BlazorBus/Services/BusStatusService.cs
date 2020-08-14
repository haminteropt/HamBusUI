using System;
using System.Collections.Generic;
using HamBusCommonStd;

namespace BlazorBus.Services
{
  public class BusStatusService: IBusStatusService
  {
    public List<BusStatusModel> BusStatusList { get; set; } = new List<BusStatusModel>();
    public void UpdateState(RigState state)
    {
      int index = BusStatusList.FindIndex(item => item.Name == state.Name);
      if (index != -1)
        BusStatusList[index].State = state;
      else {
        var bus = new BusStatusModel
        {
          Name = state.Name,
          State = state
        };
        BusStatusList.Add(bus);
      }
    }

    public void UpdateActiveBuses(ActiveBusesModel bus)
    {
      int index = BusStatusList.FindIndex(item => item.Name.Equals(bus.Name));
      if (index != -1)
        BusStatusList[index].ActiveBus = bus;
      else
      {
        var activeBbus = new BusStatusModel();
        activeBbus.Name = bus.Name;
        activeBbus.State = bus.State;
        activeBbus.ActiveBus = bus;
        BusStatusList.Add(activeBbus);
      }
    }

    public void UpdateDataBaseConfig(BusConfigurationDB bus)
    {
      int index = BusStatusList.FindIndex(item => item.Name.Equals(bus.Name));
      if (index != -1)
        BusStatusList[index].BusDbConfig = bus;
      else
      {
        var busStatus = new BusStatusModel();
        busStatus.Name = bus.Name;

        busStatus.BusDbConfig = bus;
        BusStatusList.Add(busStatus);
      }
    }

    public void UpdateFromInfoPacket(UiInfoPacketModel infoList)
    {
      foreach(var aBus in infoList.ActiveBuses)
      {
        UpdateActiveBuses(aBus);
      }

    }
  }
}
