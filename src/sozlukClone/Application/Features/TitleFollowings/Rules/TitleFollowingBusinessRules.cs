using Application.Factories.TitleBlockingServiceFactory;
using Application.Features.TitleFollowings.Constants;
using Application.Services.Repositories;
using Application.Services.TitleBlockings;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.TitleFollowings.Rules;

public class TitleFollowingBusinessRules : BaseBusinessRules
{
    private readonly ITitleFollowingRepository _titleFollowingRepository;
    private readonly ILocalizationService _localizationService;
    private readonly ITitleBlockingServiceFactory _titleBlockingServiceFactory;

    public TitleFollowingBusinessRules(ITitleFollowingRepository titleFollowingRepository, ILocalizationService localizationService, ITitleBlockingServiceFactory titleBlockingServiceFactory)
    {
        _titleFollowingRepository = titleFollowingRepository;
        _localizationService = localizationService;
        _titleBlockingServiceFactory = titleBlockingServiceFactory;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TitleFollowingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TitleFollowingShouldExistWhenSelected(TitleFollowing? titleFollowing)
    {
        if (titleFollowing == null)
            await throwBusinessException(TitleFollowingsBusinessMessages.TitleFollowingNotExists);
    }

    public async Task TitleFollowingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TitleFollowing? titleFollowing = await _titleFollowingRepository.GetAsync(
            predicate: tf => tf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TitleFollowingShouldExistWhenSelected(titleFollowing);
    }

    public async Task TitleFollowingShouldNotDuplicatedWhenInserted(TitleFollowing titleFollowing, CancellationToken cancellationToken)
    {
        TitleFollowing? existingTitleFollowing = await _titleFollowingRepository.GetAsync(
            predicate: tf => tf.TitleId == titleFollowing.TitleId && tf.AuthorId == titleFollowing.AuthorId,
            cancellationToken: cancellationToken
        );

        if (existingTitleFollowing != null)
            await throwBusinessException(TitleFollowingsBusinessMessages.TitleFollowingAlreadyExists);
    }

    public async Task TitleBlockingShouldNotExistWhenFollowingInserted(TitleFollowing titleFollowing, CancellationToken cancellationToken)
    {
        ITitleBlockingService titleBlockingService = _titleBlockingServiceFactory.Create();

        TitleBlocking? titleBlocking = await titleBlockingService.GetAsync(
            tb => tb.TitleId == titleFollowing.TitleId && tb.AuthorId == titleFollowing.AuthorId,
            cancellationToken: cancellationToken
        );

        if (titleBlocking != null)
            await throwBusinessException(TitleFollowingsBusinessMessages.TitleBlockingExists);
    }

}