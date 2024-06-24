using Application.Factories.AuthorBlockingServiceFactory;
using Application.Features.AuthorFollowings.Constants;
using Application.Services.AuthorBlockings;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.AuthorFollowings.Rules;

public class AuthorFollowingBusinessRules : BaseBusinessRules
{
    private readonly IAuthorFollowingRepository _authorFollowingRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IAuthorBlockingServiceFactory _authorBlockingServiceFactory;

    public AuthorFollowingBusinessRules(IAuthorFollowingRepository authorFollowingRepository, ILocalizationService localizationService, IAuthorBlockingServiceFactory authorBlockingServiceFactory)
    {
        _authorFollowingRepository = authorFollowingRepository;
        _localizationService = localizationService;
        _authorBlockingServiceFactory = authorBlockingServiceFactory;
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

    public async Task FollowingShouldNotDuplicatedWhenInserted(AuthorFollowing following, CancellationToken cancellationToken)
    {
        AuthorFollowing? existingFollowing = await _authorFollowingRepository.GetAsync(
            predicate: af => af.FollowingId == following.FollowingId && af.FollowerId == following.FollowerId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (existingFollowing != null)
            await throwBusinessException(AuthorFollowingsBusinessMessages.FollowingAlreadyExists);
    }

    public async Task FollowingShouldNotOwnedByEntryAuthorWhenSelected(AuthorFollowing following, CancellationToken cancellationToken)
    {
        if (following.FollowingId == following.FollowerId)
            await throwBusinessException(AuthorFollowingsBusinessMessages.FollowingIsOwnerOfItself);
    }

    public async Task BlockingShouldNotExistsWhenFollowingInserted(AuthorFollowing following, CancellationToken cancellationToken)
    {
        IAuthorBlockingService authorBlockingService = _authorBlockingServiceFactory.Create();

        AuthorBlocking? existingBlocking = await authorBlockingService.GetAsync(
                predicate: b => b.BlockingId == following.FollowingId && b.BlockerId == following.FollowerId,
                cancellationToken: cancellationToken);

        if (existingBlocking != null)
        {
            await throwBusinessException(AuthorFollowingsBusinessMessages.BlockingExists);
        }
    }
}