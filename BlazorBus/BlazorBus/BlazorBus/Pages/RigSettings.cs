using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorBus.Services;
using HamBusCommonStd;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorBus.Pages
{
  public class DRigConf : BusConfigBase
  {
    public DRigConf() { }

    [Required]
    public string name { get; set; }
    [Required]
    public string commPortName { get; set; }
    [Required]
    public int baudRate { get; set; } = 9600;
    [Required]
    public string parity { get; set; } = "";
    [Required]
    public int dataBits { get; set; } = 8;
    [Required]
    public string stopBits { get; set; } = "";
    // TODO do string handshake codes
    [Required]
    public string handshake { get; set; } = "none";
    public int? readTimeout { get; set; }
    public int? writeTimeout { get; set; } = null;
  }
  public partial class RigSettings
  {
    [Inject]
    IJSRuntime JS { get; set; }
    [Inject]
    public IActiveBusesService ActiveBusServie { get; set; }
    [Inject]
    public IBusStatusService BusService { get; set; }
    [Inject]
    private NavigationManager navMgr { get; set; }
    [Parameter]
    public string Name { get; set; }

    public DRigConf Config { get; set; }

    public bool isNotNew { get; set; } = true;

    public RigSettings()
    {
      Config = new DRigConf();
    }
 
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
        isNotNew = false;
        Console.WriteLine("busConf not found");
        Config = new DRigConf();
      }
      else {
        isNotNew = true;
        Config = JsonSerializer.Deserialize<DRigConf>(busConf.Configuration);
        Console.WriteLine($"busConf speed: {Config.baudRate} {Config.baudRate.GetType()}");
        Config.dataBits = 7;
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
    public async Task Success()
    {
      await JS.InvokeAsync<object>("alert", "Successful login!");
    }
    public void HandleValidSubmit()
    {

    }
    public void CancelClick()
    {
      Console.WriteLine("Cancel");
    }
    public void SaveClick()
    {
      Console.WriteLine("Save");
    }
    public void HomeClick()
    {
      navMgr.NavigateTo($"/");
    }
  }
}
