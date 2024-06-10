using FluentValidation;

namespace Application.Features.GlobalSettings.Commands.Create;

public class CreateGlobalSettingCommandValidator : AbstractValidator<CreateGlobalSettingCommand>
{
    public CreateGlobalSettingCommandValidator()
    {
    }
}