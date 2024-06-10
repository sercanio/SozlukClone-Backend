using FluentValidation;

namespace Application.Features.AuthorSettings.Commands.Create;

public class CreateAuthorSettingCommandValidator : AbstractValidator<CreateAuthorSettingCommand>
{
    public CreateAuthorSettingCommandValidator()
    {
        RuleFor(c => c.ProfilePictureUrl).NotEmpty();
        RuleFor(c => c.CoverPictureUrl).NotEmpty();
        RuleFor(c => c.ActiveBadgeId).NotEmpty();
    }
}