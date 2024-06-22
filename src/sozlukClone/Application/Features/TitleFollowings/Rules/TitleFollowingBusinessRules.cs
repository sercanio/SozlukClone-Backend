using Application.Features.TitleFollowings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TitleFollowings.Rules;

public class TitleFollowingBusinessRules : BaseBusinessRules
{
    private readonly ITitleFollowingRepository _titleFollowingRepository;
    private readonly ILocalizationService _localizationService;

    public TitleFollowingBusinessRules(ITitleFollowingRepository titleFollowingRepository, ILocalizationService localizationService)
    {
        _titleFollowingRepository = titleFollowingRepository;
        _localizationService = localizationService;
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
}