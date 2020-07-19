using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorBus.Services
{
  public interface IHamSignalRService
  {
    Task<HubConnection> StartService(string url);
  }
}
