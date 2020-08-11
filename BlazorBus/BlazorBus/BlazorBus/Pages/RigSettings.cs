using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBus.Services;
using HamBusCommonStd;
using Microsoft.AspNetCore.Components;

namespace BlazorBus.Pages
{
  public partial class RigSettings
  {
    [Inject]
    public IActiveBusesService ActiveBusServie { get; set; }
    [Inject]
    public IBusStatusService BusService { get; set; }
    [Parameter]
    public string Name { get; set; }

    public RigConf Config { get; set; }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
      var busConf = BusService.FindByName(Name);
      if (busConf == null) Console.WriteLine("busConf not found");
      else Console.WriteLine("busConf  found");

    }
    public void HandleValidSubmit()
    {

    }
  }
}
