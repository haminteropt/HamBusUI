using System;
using System.Collections.Generic;
using HamBusCommonStd;

namespace BlazorBus.Services
{
  public class BusStatusService: IBusStatusService
  {
    public List<BusStatusModel> BusStatusList { get; set; } = new List<BusStatusModel>();
    public List<BusConfigurationDB>? BusDbConfig { get; set; } = new List<BusConfigurationDB>();
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
    public void UpdateBusConfig(BusConfigurationDB bus)
    {
      int index = BusDbConfig!.FindIndex(item => item.Name.Equals(bus.Name));
      if (index != -1)
        BusDbConfig[index] = bus;
      else
      {
        BusDbConfig.Add(bus);
      }
    }
    public BusConfigurationDB? FindByName(string name)
    {
      int index = BusDbConfig!.FindIndex(item => item.Name.Equals(name));
      if (index < 0) return null;
      return BusDbConfig[index];
    }
    public void UpdateFromInfoPacket(UiInfoPacketModel infoList)
    {
      foreach(var aBus in infoList.ActiveBuses)
      {
        UpdateActiveBuses(aBus);
      }
      foreach(var item in infoList.BusesInDb)
      {
        UpdateBusConfig(item);
      }
    }
  }
}
