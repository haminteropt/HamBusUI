using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamBusBlazorLibrary.Services;

namespace BlazorBus.Services
{
  public class HamSignalRService : IHamSignalRService
  {
    public HamSignalRService()
    {
      Console.WriteLine("HamSignalService is instan");
    }
  }
}
