using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorBus.Services;
using HamBusCommonStd;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorBus.Pages
{

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

    public RigConf Config { get; set; }

    public bool isNotNew { get; set; } = true;
    public EditContext EC { get; set; }
    public BusType RigType { get; set; }
    // Methods
    public RigSettings()
    {
      Config = new RigConf();
    }
    protected override void OnInitialized()
    {
      EC = new EditContext(Config);
      base.OnInitialized();
    }
    protected override async Task OnParametersSetAsync()
    {
;
      var options = new JsonSerializerOptions()
      {
        WriteIndented = true
      };
      var busConf = BusService.FindByName(Name);
      if (busConf == null)
      {
        isNotNew = false;
        Config = new RigConf();
      }
      else {
        isNotNew = true;
        Config = JsonSerializer.Deserialize<RigConf>(busConf.Configuration);

        Config.dataBits = 7;
        StateHasChanged();
      }
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {

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
      Console.WriteLine("in valid handler");
    }
    public void CancelClick()
    {
      Console.WriteLine("Cancel");
    }
    public void SaveClick()
    {
      var f = EC.Field("name");
      var isvalid = EC.Validate();
      Console.WriteLine("Save");
    }
    public void HomeClick()
    {
      navMgr.NavigateTo($"/");
    }
  }
}
