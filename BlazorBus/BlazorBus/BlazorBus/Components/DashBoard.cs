using System;
using System.Collections.Generic;
using System.Linq;
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
      //SigR.InfoPacket__.Subscribe<UiInfoPacketModel>((info) =>
      //{
      //  Console.WriteLine(info.ToString());
      //});
    }
    void Change(MouseEventArgs e)
    {
      StyleToRender =
         StyleBuilder.Default("background-color", "red")
         .AddStyle("border", "1px solid black")
       .Build();
    }
    //protected async override Task OnAfterRenderAsync(bool firstRender)
    //{

      
    //}
  }
}
