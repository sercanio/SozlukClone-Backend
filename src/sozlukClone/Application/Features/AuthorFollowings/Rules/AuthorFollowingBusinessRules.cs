using Application.Features.AuthorFollowings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AuthorFollowings.Rules;

public class AuthorFollowingBusinessRules : BaseBusinessRules
{
    private readonly IAuthorFollowingRepository _authorFollowingRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorFollowingBusinessRules(IAuthorFollowingRepository authorFollowingRepository, ILocalizationService localizationService)
    {
        _authorFollowingRepository = authorFollowingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorFollowingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorFollowingShouldExistWhenSelected(AuthorFollowing? authorFollowing)
    {
        if (authorFollowing == null)
            await throwBusinessException(AuthorFollowingsBusinessMessages.AuthorFollowingNotExists);
    }

    public async Task AuthorFollowingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AuthorFollowing? authorFollowing = await _authorFollowingRepository.GetAsync(
            predicate: af => af.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorFollowingShouldExistWhenSelected(authorFollowing);
    }
}