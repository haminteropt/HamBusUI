using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorBus.Services;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBus.Components
{
  public partial class DashBoard
  {
    public string FirstRadio { get; set; }
    [Inject]
    public IHamSignalRService SigR { get; set; }
    protected string StyleToRender;

    void Change(MouseEventArgs e)
    {
      StyleToRender  =
         StyleBuilder.Default("background-color", "red")
         .AddStyle("border", "1px solid black")
       .Build();

    }
    protected override void OnAfterRender(bool firstRender)
    {

      //Thread.Sleep(10000);
      //FirstRadio = new CssBuilder()
      //                    .AddClass("radio-color")
      //                    .Build();


    }

  }
}
