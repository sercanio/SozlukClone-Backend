using FluentValidation;

namespace Application.Features.AuthorSettings.Commands.Update;

public class UpdateAuthorSettingCommandValidator : AbstractValidator<UpdateAuthorSettingCommand>
{
    public UpdateAuthorSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfilePictureUrl).NotEmpty();
        RuleFor(c => c.CoverPictureUrl).NotEmpty();
        RuleFor(c => c.AuthorGroupId).NotEmpty();
        RuleFor(c => c.ActiveBadgeId).NotEmpty();
    }
}