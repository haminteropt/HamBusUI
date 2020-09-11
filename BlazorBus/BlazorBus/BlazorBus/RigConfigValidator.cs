using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HamBusCommonStd;

namespace BlazorBus
{
  public class RigConfigValidator : AbstractValidator<RigConf>
  {
    public RigConfigValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
    }
  }
}
