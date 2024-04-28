using Application.Features.Badges.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Badges.Rules;

public class BadgeBusinessRules : BaseBusinessRules
{
    private readonly IBadgeRepository _badgeRepository;
    private readonly ILocalizationService _localizationService;

    public BadgeBusinessRules(IBadgeRepository badgeRepository, ILocalizationService localizationService)
    {
        _badgeRepository = badgeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BadgesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BadgeShouldExistWhenSelected(Badge? badge)
    {
        if (badge == null)
            await throwBusinessException(BadgesBusinessMessages.BadgeNotExists);
    }

    public async Task BadgeIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        Badge? badge = await _badgeRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BadgeShouldExistWhenSelected(badge);
    }
}