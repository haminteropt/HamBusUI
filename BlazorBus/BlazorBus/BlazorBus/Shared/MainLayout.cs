﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorBus.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Serilog;

namespace BlazorBus.Shared
{
  public partial class MainLayout : LayoutComponentBase
  {
    [Inject]
    public IHamSignalRService? SigR { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      try
      {
        if (firstRender)
        {
          if (SigR == null) return;
          var conn = await SigR.StartService("http://localhost:7300/masterbus");
          List<string> groupList = new List<string>();
          groupList.Add("logging");
          groupList.Add("ui");
          groupList.Add("control");
          await SigR.Login(groupList, "control");
        }
      }
      catch (Exception e)
      {
        Log.Error("Error in starting SignalR {@e}");
      }
    }
  }
}
