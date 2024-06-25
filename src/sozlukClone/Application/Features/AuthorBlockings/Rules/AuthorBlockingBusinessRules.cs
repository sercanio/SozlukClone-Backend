using Application.Factories.AuthorBlockingServiceFactory;
using Application.Features.AuthorBlockings.Constants;
using Application.Services.AuthorFollowings;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.AuthorBlockings.Rules;

public class AuthorBlockingBusinessRules : BaseBusinessRules
{
    private readonly IAuthorBlockingRepository _authorBlockingRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IAuthorFollowingServiceFactory _authorFollowingServiceFactory;

    public AuthorBlockingBusinessRules(IAuthorBlockingRepository authorBlockingRepository, ILocalizationService localizationService, IAuthorFollowingServiceFactory authorFollowingServiceFactory)
    {
        _authorBlockingRepository = authorBlockingRepository;
        _localizationService = localizationService;
        _authorFollowingServiceFactory = authorFollowingServiceFactory;
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

    public async Task BlockingShouldNotOwnedByEntryAuthorWhenSelected(AuthorBlocking authorBlocking, CancellationToken cancellationToken)
    {
        if (authorBlocking.BlockingId == authorBlocking.BlockerId)
            await throwBusinessException(AuthorBlockingsBusinessMessages.BlockingShouldNotOwnedByEntryAuthor);
    }

    public async Task BlockingShouldNotDuplicatedWhenInserted(AuthorBlocking authorBlocking, CancellationToken cancellationToken)
    {
        AuthorBlocking? existingBlocking = await _authorBlockingRepository.GetAsync(
            predicate: ab => ab.BlockingId == authorBlocking.BlockingId && ab.BlockerId == authorBlocking.BlockerId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (existingBlocking != null)
            await throwBusinessException(AuthorBlockingsBusinessMessages.BlockingShouldNotDuplicated);
    }

    public async Task FollowingShouldNotExistsWhenFollowingInserted(AuthorBlocking blocking, CancellationToken cancellationToken)
    {
        IAuthorFollowingService authorBlockingService = _authorFollowingServiceFactory.Create();

        AuthorFollowing? existingFollowing = await authorBlockingService.GetAsync(
                predicate: f => f.FollowingId == blocking.BlockingId && f.FollowerId == blocking.BlockerId,
                cancellationToken: cancellationToken);

        if (existingFollowing != null)
        {
            await throwBusinessException(AuthorBlockingsBusinessMessages.FollowingExists);
        }
    }
}