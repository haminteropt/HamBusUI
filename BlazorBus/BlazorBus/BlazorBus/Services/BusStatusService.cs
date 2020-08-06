using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamBusCommonStd;

namespace BlazorBus.Services
{
  public class BusStatusService
  {
    public List<BusStatusModel> BusModelList { get; set; } = new List<BusStatusModel>();
    public void UpdateState(RigState state)
    {
      int index = BusModelList.FindIndex(item => item.Name.Equals(state.Name));
      if (index != -1)
        BusModelList[index].State = state;
      else {
        var bus = new BusStatusModel();
        bus.Name = state.Name;
        bus.State = state;
        BusModelList.Add(bus);
      }
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
        activeBbus.ActiveBus = bus;
        BusModelList.Add(activeBbus);
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
