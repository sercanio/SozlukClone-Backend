using Application.Features.AuthorBlockings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AuthorBlockings.Rules;

public class AuthorBlockingBusinessRules : BaseBusinessRules
{
    private readonly IAuthorBlockingRepository _authorBlockingRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorBlockingBusinessRules(IAuthorBlockingRepository authorBlockingRepository, ILocalizationService localizationService)
    {
        _authorBlockingRepository = authorBlockingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorBlockingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorBlockingShouldExistWhenSelected(AuthorBlocking? authorBlocking)
    {
        if (authorBlocking == null)
            await throwBusinessException(AuthorBlockingsBusinessMessages.AuthorBlockingNotExists);
    }

    public async Task AuthorBlockingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AuthorBlocking? authorBlocking = await _authorBlockingRepository.GetAsync(
            predicate: ab => ab.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorBlockingShouldExistWhenSelected(authorBlocking);
    }
}