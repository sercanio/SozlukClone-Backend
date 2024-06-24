using FluentValidation;

namespace Application.Features.TitleFollowings.Commands.Delete;

public class DeleteTitleFollowingCommandValidator : AbstractValidator<DeleteTitleFollowingCommand>
{
    public DeleteTitleFollowingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}