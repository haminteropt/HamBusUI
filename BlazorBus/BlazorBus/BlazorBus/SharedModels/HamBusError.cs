using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBus.SharedModels
{
  public enum HamBusErrorNum { NoError = 0, NoConfigure, Unknown }
  public class HaBusError
  {
    public string Message { get; set; } = "something";
    public HamBusErrorNum ErrorNum { get; set; } = HamBusErrorNum.Unknown;
  }
}
