using FluentValidation;

namespace Application.Features.Complaints.Commands.Update;

public class UpdateComplaintCommandValidator : AbstractValidator<UpdateComplaintCommand>
{
    public UpdateComplaintCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.Details).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}