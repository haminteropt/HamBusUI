using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorBus.SharedModels
{
  public  class HamBusBase
  {
    public override string ToString()
    {
      var options = new JsonSerializerOptions
      {
        //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
      };

      return JsonSerializer.Serialize(this,options);
    }
  }
}
