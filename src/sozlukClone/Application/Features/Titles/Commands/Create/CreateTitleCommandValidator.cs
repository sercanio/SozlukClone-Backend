using FluentValidation;

namespace Application.Features.Titles.Commands.Create;

public class CreateTitleCommandValidator : AbstractValidator<CreateTitleCommand>
{
    public CreateTitleCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}