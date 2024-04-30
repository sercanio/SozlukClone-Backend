using FluentValidation;

namespace Application.Features.TitleSettings.Commands.Update;

public class UpdateTitleSettingCommandValidator : AbstractValidator<UpdateTitleSettingCommand>
{
    public UpdateTitleSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MinTitleLength).NotNull().NotEmpty();
        RuleFor(c => c.MaxTitleLength).NotNull().NotEmpty();
        RuleFor(c => c.TitleCanHaveLink).NotNull();
        RuleFor(c => c.TitleCanHaveSpecialCharacter).NotNull();
        RuleFor(c => c.TitleCanHavePunctuation).NotNull();
    }
}