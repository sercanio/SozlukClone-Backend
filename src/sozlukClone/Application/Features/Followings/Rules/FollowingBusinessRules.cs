using Application.Features.Followings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Followings.Rules;

public class FollowingBusinessRules : BaseBusinessRules
{
    private readonly IFollowingRepository _followingRepository;
    private readonly ILocalizationService _localizationService;

    public FollowingBusinessRules(IFollowingRepository followingRepository, ILocalizationService localizationService)
    {
        _followingRepository = followingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FollowingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FollowingShouldExistWhenSelected(Following? following)
    {
        if (following == null)
            await throwBusinessException(FollowingsBusinessMessages.FollowingNotExists);
    }

    public async Task FollowingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Following? following = await _followingRepository.GetAsync(
            predicate: f => f.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FollowingShouldExistWhenSelected(following);
    }
}