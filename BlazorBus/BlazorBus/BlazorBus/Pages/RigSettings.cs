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
using Serilog;

namespace BlazorBus.Pages
{

  public partial class RigSettings
  {
    [Inject]
    IJSRuntime? JS { get; set; }
    [Inject]
    public IActiveBusesService? ActiveBusServie { get; set; }
    [Inject]
    public IBusStatusService? BusService { get; set; }
    [Inject]
    private NavigationManager? NavMgr { get; set; }
    [Inject]
    public IHamSignalRService? SigR { get; set; }
    [Parameter]
    public string? Name { get; set; }

    public RigConf Config { get; set; }

    public bool isNotNew { get; set; } = true;
    public EditContext? EC { get; set; }
    public BusType RigType { get; set; }

    private BusConfigurationDB? DbConfig { get; set; } = new BusConfigurationDB();
    // Methods
    public RigSettings()
    {
      Config = new RigConf();
    }
    protected override void OnInitialized()
    {
      Log.Verbose("on init");

      base.OnInitialized();
    }
    protected override async Task OnParametersSetAsync()
    {


      if (Name == null) return;
      DbConfig = BusService!.FindByName(Name);
      if (DbConfig == null)
      {
        isNotNew = false;
        Config = new RigConf();
      }
      else {
        isNotNew = true;
        Config = JsonSerializer.Deserialize<RigConf>(DbConfig.Configuration);

        Config.DataBits = 7;

      }
      StateHasChanged();
      if (EC == null)
        EC = new EditContext(Config);
      EC.Validate();
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
      Log.Verbose("in valid handler");
    }
    public void CancelClick()
    {
      Log.Verbose("Cancel");
    }
    public void SaveClick()
    {

      var isvalid = EC!.Validate();
      if (isvalid)
      {
        var options = new JsonSerializerOptions()
        {
          WriteIndented = true
        };
        if (DbConfig == null) DbConfig = new BusConfigurationDB();
        DbConfig.Name = Config.Name;
        DbConfig.Version = 1;
        DbConfig.BusType = Config.RigType;
        DbConfig.Configuration = JsonSerializer.Serialize<RigConf>(Config);
        SigR!.SaveConfiguration(Config.Name,DbConfig);
      }
    }
    public void HomeClick()
    {
      NavMgr!.NavigateTo($"/");
    }
  }
}
