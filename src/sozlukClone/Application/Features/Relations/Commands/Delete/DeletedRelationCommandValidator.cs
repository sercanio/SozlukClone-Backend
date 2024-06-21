using FluentValidation;

namespace Application.Features.Relations.Commands.Delete;

public class DeleteRelationCommandValidator : AbstractValidator<DeleteRelationCommand>
{
    public DeleteRelationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}