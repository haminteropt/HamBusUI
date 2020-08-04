using System.Collections.Generic;
using HamBusCommonStd;

namespace BlazorBus.Services
{
  public class ActiveBusesService
  {
    public List<ActiveBusesModel> ActiveBuses { get; set; }

    public void BusUpdate(ActiveBusesModel bus)
    {
      int index = ActiveBuses.FindIndex(item => item.Name.Equals(bus.Name));
      if (index != -1)
        ActiveBuses[index] = bus;
      else
        ActiveBuses.Add(bus);
    }
  }
}
