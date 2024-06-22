using Application.Features.TitleBlockings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TitleBlockings.Rules;

public class TitleBlockingBusinessRules : BaseBusinessRules
{
    private readonly ITitleBlockingRepository _titleBlockingRepository;
    private readonly ILocalizationService _localizationService;

    public TitleBlockingBusinessRules(ITitleBlockingRepository titleBlockingRepository, ILocalizationService localizationService)
    {
        _titleBlockingRepository = titleBlockingRepository;
        _localizationService = localizationService;
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
}