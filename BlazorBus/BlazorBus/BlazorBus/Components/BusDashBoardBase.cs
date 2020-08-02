using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorBus.Services;
using BlazorBus.SharedModels;
using BlazorComponentUtilities;
using HamBusCommmonStd;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBus.Components
{
  public class BusDashBoardBase : ComponentBase
  {
    public string FirstRadio { get; set; }
    [Inject]
    public IHamSignalRService SigR { get; set; }
    [Parameter]
    public decimal Frequency { get; set; } = 0.0m;
    private long freqLong;
    private long SerialNum { get; set; } = 0;

    protected string StyleToRender;



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
        Console.WriteLine(JsonSerializer.Serialize(info));
        Console.WriteLine("in sub");
        Console.WriteLine(info.ToString());
      });

      SigR.RigState__.Subscribe<RigState>((state) =>
      {
        Console.WriteLine($"Frequency: {Frequency} Serial Num: {state.SerialNum}");
        if (this.SerialNum == state.SerialNumDym) return;
        SerialNum = state.SerialNumDym;
        freqLong = state.Freq;
        Frequency = Convert.ToDecimal(freqLong)/ 1000000.0m;
        StateHasChanged();
        Console.WriteLine($"Frequency: {Frequency} Serial Num: {state.SerialNumDym}");

      });

    }
  }
}
