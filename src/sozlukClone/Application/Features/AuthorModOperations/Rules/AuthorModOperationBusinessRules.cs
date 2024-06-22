using Application.Features.AuthorModOperations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AuthorModOperations.Rules;

public class AuthorModOperationBusinessRules : BaseBusinessRules
{
    private readonly IAuthorModOperationRepository _authorModOperationRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorModOperationBusinessRules(IAuthorModOperationRepository authorModOperationRepository, ILocalizationService localizationService)
    {
        _authorModOperationRepository = authorModOperationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorModOperationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorModOperationShouldExistWhenSelected(AuthorModOperation? authorModOperation)
    {
        if (authorModOperation == null)
            await throwBusinessException(AuthorModOperationsBusinessMessages.AuthorModOperationNotExists);
    }

    public async Task AuthorModOperationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AuthorModOperation? authorModOperation = await _authorModOperationRepository.GetAsync(
            predicate: amo => amo.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorModOperationShouldExistWhenSelected(authorModOperation);
    }
}