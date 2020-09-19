using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HamBusCommonStd;

namespace BlazorBus.Validators
{
  public class RigSettingValidator: AbstractValidator<RigConf>
  {
    public RigSettingValidator()
    {
      RuleFor(config => config.Name).NotEmpty().MinimumLength(3);
    }
  }
}
