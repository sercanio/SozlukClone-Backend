using FluentValidation;

namespace Application.Features.TitleModOperations.Commands.Create;

public class CreateTitleModOperationCommandValidator : AbstractValidator<CreateTitleModOperationCommand>
{
    public CreateTitleModOperationCommandValidator()
    {
        RuleFor(c => c.TitleId).NotEmpty();
    }
}