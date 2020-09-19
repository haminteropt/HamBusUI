using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Serilog;

namespace BlazorBus.Pages
{
  public partial class ValidationSample
  {
    public EditContext? EC { get; set; }
    class SexDef
    {
      public string Name { get; set; }

      public SexDef(string name)
      {
        Name = name;
      }
    }

    string[] SexItems = new[]
    {
        "",
        "M",
        "W"
    };

    [Inject]
    IJSRuntime? JS { get; set; }

    async Task Success()
    {
      var v = EC!.Validate();
      Log.Verbose($"v = {@v}",v);

    }

    LoginModel myModel = new LoginModel();
    protected override void OnInitialized()
    {
      EC = new EditContext(myModel);
    }


    public class LoginModel
    {
      [Required]
      public string? Username { get; set; }

      [Required]
      [MinLength(2)]
      public string? Password { get; set; } = null;

      public string? Comment { get; set; }

    }
  }
}
