using System;
using System.Text.Json;
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

    protected override async Task OnParametersSetAsync()
    {
      Console.WriteLine("in onsetpar");
      var options = new JsonSerializerOptions()
      {
        WriteIndented = true
      };
      var busConf = BusService.FindByName(Name);
      if (busConf == null)
      {
        Console.WriteLine("busConf not found");
        Config = new RigConf();
      }
      else {
 
        Config = JsonSerializer.Deserialize<RigConf>(busConf.Configuration);
        StateHasChanged();
        Console.WriteLine($"busConf  found Name: {Config.name}");
      }
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {

      Console.WriteLine("in on after rend");

      var options = new JsonSerializerOptions()
      {
        WriteIndented = true
      };




    }
    private async Task Success()
    { }
    public void HandleValidSubmit()
    {

    }
  }
}
