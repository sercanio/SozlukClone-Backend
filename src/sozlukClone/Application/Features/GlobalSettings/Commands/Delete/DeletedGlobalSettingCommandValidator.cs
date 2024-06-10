using FluentValidation;

namespace Application.Features.GlobalSettings.Commands.Delete;

public class DeleteGlobalSettingCommandValidator : AbstractValidator<DeleteGlobalSettingCommand>
{
    public DeleteGlobalSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}