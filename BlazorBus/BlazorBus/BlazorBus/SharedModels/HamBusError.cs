using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamBusCommonStd.Model;

namespace BlazorBus.SharedModels
{
  public enum HamBusErrorNum { NoError = 0, NoConfigure, Unknown }
  public class HamBusError : HamBusBase
  {
    public string Message { get; set; } = "something";
    public HamBusErrorNum ErrorNum { get; set; } = HamBusErrorNum.Unknown;
  }
}
