using FluentValidation;

namespace Application.Features.TitleFollowings.Commands.Create;

public class CreateTitleFollowingCommandValidator : AbstractValidator<CreateTitleFollowingCommand>
{
    public CreateTitleFollowingCommandValidator()
    {
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}