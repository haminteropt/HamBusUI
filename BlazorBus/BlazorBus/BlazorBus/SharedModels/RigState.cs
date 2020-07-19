using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBus.SharedModels
{
  public class RigState : HamBusBase, ICloneable
  {
  #nullable enable
    public string? Name { get; set; }
    public long Freq { get; set; }
    public long FreqA { get; set; }
    public long FreqB { get; set; }
    public string? Mode { get; set; }
    public int Pitch { get; set; }
    public string? RigType { get; set; }
    public string? Rit { get; set; }
    public int RitOffset { get; set; }
    public string? Status { get; set; }
    public string? StatusStr { get; set; }
    public string? Split { get; set; }
    public bool Tx { get; set; }
    public string? Vfo { get; set; }
    public string? Xit { get; set; }
    #nullable disable
    public Object Clone()
    {
      return (RigState)MemberwiseClone();
    }
  }
}
