using System;
using HamBusCommonStd.Model;

namespace BlazorBus.SharedModels
{
  public class BusConfigBase : HamBusBase
  {
    public Boolean AcceptRigStateUpdates { get; set; } = false;

  }
}