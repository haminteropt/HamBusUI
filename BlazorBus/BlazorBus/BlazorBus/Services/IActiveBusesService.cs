using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamBusCommonStd;

namespace BlazorBus.Services
{
  public interface IActiveBusesService
  {
    List<ActiveBusesModel> ActiveBuses { get; set; }
    void BusUpdate(ActiveBusesModel bus);

  }
}
