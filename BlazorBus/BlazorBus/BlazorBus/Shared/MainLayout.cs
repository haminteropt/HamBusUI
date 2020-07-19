﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorBus.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorBus.Shared
{
  public partial class MainLayout
  {
    [Inject]
    public IHamSignalRService SigR { get; set; }
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
      try
      {
        if (firstRender)
        {
          var conn = await SigR.StartService("http://localhost:7300/masterbus");
          List<string> groupList = new List<string>();
          groupList.Add("radio");
          groupList.Add("logging");
          groupList.Add("ui");
          await conn.InvokeAsync("Login", "control", groupList);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}