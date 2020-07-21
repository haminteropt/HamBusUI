using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorBus.Services;
using BlazorBus.SharedModels;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBus.Components
{
  public partial class DashBoard : ComponentBase
  {
    public string FirstRadio { get; set; }
    [Inject]
    public IHamSignalRService SigR { get; set; }

    protected string StyleToRender;

    public DashBoard() 
    {

    }
    void Change(MouseEventArgs e)
    {
      StyleToRender =
         StyleBuilder.Default("background-color", "red")
         .AddStyle("border", "1px solid black")
       .Build();
    }
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
      //this causes crash
      SigR.InfoPacket__.Subscribe<UiInfoPacketModel>((info) =>
      {
        Console.WriteLine(JsonSerializer.Serialize(info));
        Console.WriteLine("in sub");
        Console.WriteLine(info.ToString());
      });

    }
  }
}
