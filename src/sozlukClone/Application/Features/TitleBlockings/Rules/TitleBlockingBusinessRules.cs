using Application.Factories.TitleFollowingServiceFactory;
using Application.Features.TitleBlockings.Constants;
using Application.Services.Repositories;
using Application.Services.TitleFollowings;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.TitleBlockings.Rules;

public class TitleBlockingBusinessRules : BaseBusinessRules
{
    private readonly ITitleBlockingRepository _titleBlockingRepository;
    private readonly ILocalizationService _localizationService;
    private readonly ITitleFollowingServiceFactory _titleFollowingServiceFactory;
    public TitleBlockingBusinessRules(ITitleBlockingRepository titleBlockingRepository, ILocalizationService localizationService, ITitleFollowingService titleFollowingService, ITitleFollowingServiceFactory titleFollowingServiceFactory)
    {
        _titleBlockingRepository = titleBlockingRepository;
        _localizationService = localizationService;
        _titleFollowingServiceFactory = titleFollowingServiceFactory;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TitleBlockingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TitleBlockingShouldExistWhenSelected(TitleBlocking? titleBlocking)
    {
        if (titleBlocking == null)
            await throwBusinessException(TitleBlockingsBusinessMessages.TitleBlockingNotExists);
    }

    public async Task TitleBlockingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TitleBlocking? titleBlocking = await _titleBlockingRepository.GetAsync(
            predicate: tb => tb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TitleBlockingShouldExistWhenSelected(titleBlocking);
    }

    public async Task TitleBlockingShouldNotDuplicatedWhenInserted(TitleBlocking titleBlocking, CancellationToken cancellationToken)
    {
        TitleBlocking? existingTitleBlocking = await _titleBlockingRepository.GetAsync(
            predicate: tf => tf.TitleId == titleBlocking.TitleId && tf.AuthorId == titleBlocking.AuthorId,
            cancellationToken: cancellationToken
        );

        if (existingTitleBlocking != null)
            await throwBusinessException(TitleBlockingsBusinessMessages.TitleBlockingAlreadyExists);
    }

    public async Task TitleFollowingShouldNotExistWhenFollowingInserted(TitleBlocking titleBlocking, CancellationToken cancellationToken)
    {
        ITitleFollowingService titleFollowingService = _titleFollowingServiceFactory.Create();

        TitleFollowing? titleFollowing = await titleFollowingService.GetAsync(
            predicate: tf => tf.TitleId == titleBlocking.TitleId && tf.AuthorId == titleBlocking.AuthorId,
            cancellationToken: cancellationToken
        );

        if (titleFollowing != null)
            await throwBusinessException(TitleBlockingsBusinessMessages.TitleFollowingExists);
    }
}