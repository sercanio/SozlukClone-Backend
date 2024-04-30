using Application.Features.TitleSettings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TitleSettings.Rules;

public class TitleSettingBusinessRules : BaseBusinessRules
{
    private readonly ITitleSettingRepository _titleSettingRepository;
    private readonly ILocalizationService _localizationService;

    public TitleSettingBusinessRules(ITitleSettingRepository titleSettingRepository, ILocalizationService localizationService)
    {
        _titleSettingRepository = titleSettingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TitleSettingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TitleSettingShouldExistWhenSelected(TitleSetting? titleSetting)
    {
        if (titleSetting == null)
            await throwBusinessException(TitleSettingsBusinessMessages.TitleSettingNotExists);
    }

    public async Task TitleSettingIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        TitleSetting? titleSetting = await _titleSettingRepository.GetAsync(
            predicate: ts => ts.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TitleSettingShouldExistWhenSelected(titleSetting);
    }
}