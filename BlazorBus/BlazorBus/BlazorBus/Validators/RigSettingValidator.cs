using BlazorBus.Pages;
using FluentValidation;
using HamBusCommonStd;

namespace BlazorBus.Validators
{
  public class RigSettingValidator : AbstractValidator<RigConf>
  {
    public RigSettingValidator()
    {
      RuleFor(r => r.name.Length).GreaterThan(3).WithMessage("Must have name");
      RuleFor(r => r.commPortName.Length).GreaterThan(3).WithMessage("Must have COM Port");
    }
  }
}
