using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using BlazorBus.Services;
using BlazorComponentUtilities;
using HamBusCommonStd;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBus.Components
{
  public class BusDashBoardBase : ComponentBase
  {
    public string FirstRadio { get; set; }

    [Inject]
    public IActiveBusesService ActiveBusServie { get; set; }
    [Inject]
    public IBusStatusService BusService { get; set; }
    [Inject]
    public IHamSignalRService SigR { get; set; }

    [Parameter]

    public decimal Frequency { get; set; } = 0.0m;

    public string activeClass = "active";
    public string inActiveClass = "inActive";
    private long freqLong;
    private long SerialNum { get; set; } = 0;

    protected string StyleToRender;

    public string GetClass(bool isActive)
    {
      if (isActive) return activeClass;
      return inActiveClass;
    }
    public string FormatFreq()
    {
      var f = Frequency;
      Console.WriteLine($"freq: {f}  {Frequency}");
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

      SigR.InfoPacket__.Subscribe<UiInfoPacketModel>((info) =>
      {
        ActiveBusServie.ActiveBuses = info.ActiveBuses;
        foreach (var active in info.ActiveBuses)
        {
          UpdateNewState(active.State);
          Console.WriteLine($"info: {active.Name}");
        }
        StateHasChanged();
      });

      SigR.ActiveUpdate__.Subscribe(active =>
      {
        HandleActiveBusUpdate(active);
      });
      SigR.RigState__.Subscribe((state) =>
      {
        UpdateNewState(state);

      });

    }

    private void HandleActiveBusUpdate(ActiveBusesModel active)
    {
      Console.WriteLine($"active.freq: {active.State.Freq}");
      UpdateNewState(active.State);
      ActiveBusServie.BusUpdate(active);
      if (active.IsActive)
        Console.WriteLine($"Bus {active.Name} added");
      else
        Console.WriteLine($"Bus {active.Name} removed");
      StateHasChanged();
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
