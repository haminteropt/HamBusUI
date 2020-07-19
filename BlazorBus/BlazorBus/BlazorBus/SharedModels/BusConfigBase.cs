using System;

namespace BlazorBus.SharedModels
{
  public class BusConfigBase : HamBusBase
  {
    public Boolean AcceptRigStateUpdates { get; set; } = false;

  }
}