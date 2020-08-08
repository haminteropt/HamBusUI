using System;
using System.Collections.Generic;
using HamBusCommonStd;

namespace BlazorBus.Services
{
  public class BusStatusService: IBusStatusService
  {
    public List<BusStatusModel> BusModelList { get; set; } = new List<BusStatusModel>();
    public void UpdateState(RigState state)
    {
      int index = BusModelList.FindIndex(item => item.Name == state.Name);
      if (index != -1)
        BusModelList[index].State = state;
      else {
        var bus = new BusStatusModel();
        bus.Name = state.Name;
        bus.State = state;
        BusModelList.Add(bus);
      }
    }

    public void TestMethod()
    {
      Console.WriteLine("in test method");
    }
    public void UpdateActiveBuses(ActiveBusesModel bus)
    {
      int index = BusModelList.FindIndex(item => item.Name.Equals(bus.Name));
      if (index != -1)
        BusModelList[index].ActiveBus = bus;
      else
      {
        var activeBbus = new BusStatusModel();
        activeBbus.Name = bus.Name;
        activeBbus.State = bus.State;
        activeBbus.ActiveBus = bus;
        BusModelList.Add(activeBbus);
      }
    }
    public void UpdateFromInfoPacket(UiInfoPacketModel infoList)
    {
      Console.WriteLine("in updatefrominfopacket");
      foreach(var aBus in infoList.ActiveBuses)
      {
        Console.WriteLine($"Freq from master: {aBus.State.Freq}");
        UpdateActiveBuses(aBus);
      }
 
    }
  }
}
