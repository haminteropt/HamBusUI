using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBus.SharedModels
{
  public class UiInfoPacketModel : HamBusBase
  {
    public List<ActiveBusesModel> ActiveBuses { get; set; } = new List<ActiveBusesModel>();
    public List<BusConfigurationDB> BusesInDb { get; set; } = new List<BusConfigurationDB>();
  }
}
