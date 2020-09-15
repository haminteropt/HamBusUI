using System;
using System.Reactive.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorBus.Services;
using BlazorComponentUtilities;
using HamBusCommonStd;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Serilog;

namespace BlazorBus.Components
{
  public class BusDashBoardBase : ComponentBase
  {
    public string? FirstRadio { get; set; } = null;

    [Inject]
    public IActiveBusesService? ActiveBusServie { get; set; } = null;
    [Inject]
    public IBusStatusService? BusService { get; set; }
    [Inject]
    public IHamSignalRService? SigR { get; set; }

    [Parameter]

    public decimal Frequency { get; set; } = 0.0m;

    public string activeClass = "active";
    public string inActiveClass = "inActive";
    private long freqLong;
    private long SerialNum { get; set; } = 0;

    protected string? StyleToRender;
    [Inject]
    private NavigationManager? navMgr { get; set; }

    public BusDashBoardBase()
    {
      Log.Information("in BusDashBoardBase con");

    }
    public string GetClass(bool isActive)
    {
      if (isActive) return activeClass;
      return inActiveClass;
    }
    public string FormatFreq(BusStatusModel busName)
    {
      var f = busName.State.Freq/1000000m;
      return f.ToString();
    }

    public void Change(MouseEventArgs e)
    {

      StyleToRender =
         StyleBuilder.Default("background-color", "red")
         .AddStyle("border", "1px solid black")
       .Build();
    }
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {

      SigR!.InfoPacket__.Subscribe<UiInfoPacketModel>((info) =>
      {
        ActiveBusServie!.ActiveBuses = info.ActiveBuses;
        foreach (var active in info.ActiveBuses)
        {
          UpdateNewState(active.State);
        }
        StateHasChanged();
        Log.Debug("in info subj {@info}",info);
      });

      SigR.ActiveUpdate__.Subscribe(active =>
      {
        HandleActiveBusUpdate(active);
        Console.WriteLine("in active sub");
      });

      SigR.RigState__.Subscribe((state) =>
      {
        UpdateNewState(state);
        Log.Warning("in state sub");

      });

    }

    private void HandleActiveBusUpdate(ActiveBusesModel active)
    {
      UpdateNewState(active.State);
      ActiveBusServie!.BusUpdate(active);
      StateHasChanged();
    }
    JsonSerializerOptions options = new JsonSerializerOptions
    {
      //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = true
    };

    public void LockClick(bool e, BusStatusModel bus)
    {
      Console.WriteLine($"name: {bus.Name} toggle: {e}");
      var lockDTO = new LockModel();
      lockDTO.Name = bus.Name;
      lockDTO.IsStateLocked = e;
      SigR!.SetLock(lockDTO);

    }
    public void SettingsClick(BusStatusModel bus)
    {
      navMgr!.NavigateTo($"/RigSettings/{bus.Name}");
    }

    private void UpdateNewState(RigState state)
    {
      if (this.SerialNum == state.SerialNumDym) return;
      SerialNum = state.SerialNumDym;
      freqLong = state.Freq;
      Frequency = Convert.ToDecimal(freqLong) / 1000000.0m;
      StateHasChanged();
    }
  }
}
