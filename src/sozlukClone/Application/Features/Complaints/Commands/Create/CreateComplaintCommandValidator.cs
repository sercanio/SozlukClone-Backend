using FluentValidation;

namespace Application.Features.Complaints.Commands.Create;

public class CreateComplaintCommandValidator : AbstractValidator<CreateComplaintCommand>
{
    public CreateComplaintCommandValidator()
    {
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.Details).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}