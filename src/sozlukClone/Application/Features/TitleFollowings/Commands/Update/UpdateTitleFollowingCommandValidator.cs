using FluentValidation;

namespace Application.Features.TitleFollowings.Commands.Update;

public class UpdateTitleFollowingCommandValidator : AbstractValidator<UpdateTitleFollowingCommand>
{
    public UpdateTitleFollowingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}