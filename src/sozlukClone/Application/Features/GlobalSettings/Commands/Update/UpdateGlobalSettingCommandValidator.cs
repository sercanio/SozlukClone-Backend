using FluentValidation;

namespace Application.Features.GlobalSettings.Commands.Update;

public class UpdateGlobalSettingCommandValidator : AbstractValidator<UpdateGlobalSettingCommand>
{
    public UpdateGlobalSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}