using FluentValidation;

namespace Application.Features.TitleModOperations.Commands.Delete;

public class DeleteTitleModOperationCommandValidator : AbstractValidator<DeleteTitleModOperationCommand>
{
    public DeleteTitleModOperationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}