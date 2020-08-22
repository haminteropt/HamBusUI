using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorBus.Pages
{
  public class DRigConf 
  {
    public DRigConf() { }

    [Required]
    public string name { get; set; }

  }
  public partial class RigSettings
  {
    [Inject]
    IJSRuntime JS { get; set; }

    public DRigConf Config { get; set; } = new DRigConf();
 
    public async Task Success()
    {
      await JS.InvokeAsync<object>("alert", "Successful login!");
    }
  }
}
