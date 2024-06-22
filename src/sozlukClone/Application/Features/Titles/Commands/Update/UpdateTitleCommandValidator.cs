using FluentValidation;

namespace Application.Features.Titles.Commands.Update;

public class UpdateTitleCommandValidator : AbstractValidator<UpdateTitleCommand>
{
    public UpdateTitleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}