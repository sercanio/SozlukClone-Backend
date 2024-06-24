using FluentValidation;

namespace Application.Features.Complaints.Commands.Delete;

public class DeleteComplaintCommandValidator : AbstractValidator<DeleteComplaintCommand>
{
    public DeleteComplaintCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}