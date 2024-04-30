using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AuthorGroupUserOperationClaims.Rules;

public class AuthorGroupUserOperationClaimBusinessRules : BaseBusinessRules
{
    private readonly IAuthorGroupUserOperationClaimRepository _authorGroupUserOperationClaimRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorGroupUserOperationClaimBusinessRules(IAuthorGroupUserOperationClaimRepository authorGroupUserOperationClaimRepository, ILocalizationService localizationService)
    {
        _authorGroupUserOperationClaimRepository = authorGroupUserOperationClaimRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorGroupUserOperationClaimsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorGroupUserOperationClaimShouldExistWhenSelected(AuthorGroupUserOperationClaim? authorGroupUserOperationClaim)
    {
        if (authorGroupUserOperationClaim == null)
            await throwBusinessException(AuthorGroupUserOperationClaimsBusinessMessages.AuthorGroupUserOperationClaimNotExists);
    }

    public async Task AuthorGroupUserOperationClaimIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AuthorGroupUserOperationClaim? authorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.GetAsync(
            predicate: aguoc => aguoc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorGroupUserOperationClaimShouldExistWhenSelected(authorGroupUserOperationClaim);
    }
}