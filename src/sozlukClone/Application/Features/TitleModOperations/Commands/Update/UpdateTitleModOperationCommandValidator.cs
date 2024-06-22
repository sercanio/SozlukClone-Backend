using FluentValidation;

namespace Application.Features.TitleModOperations.Commands.Update;

public class UpdateTitleModOperationCommandValidator : AbstractValidator<UpdateTitleModOperationCommand>
{
    public UpdateTitleModOperationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.ModOperationId).NotEmpty();
    }
}