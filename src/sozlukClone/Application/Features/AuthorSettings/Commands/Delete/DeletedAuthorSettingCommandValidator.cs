using FluentValidation;

namespace Application.Features.AuthorSettings.Commands.Delete;

public class DeleteAuthorSettingCommandValidator : AbstractValidator<DeleteAuthorSettingCommand>
{
    public DeleteAuthorSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}