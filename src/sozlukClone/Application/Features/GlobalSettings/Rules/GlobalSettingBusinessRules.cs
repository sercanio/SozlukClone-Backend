using Application.Features.GlobalSettings.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.GlobalSettings.Rules;

public class GlobalSettingBusinessRules : BaseBusinessRules
{
    private readonly IGlobalSettingRepository _globalSettingRepository;
    private readonly ILocalizationService _localizationService;

    public GlobalSettingBusinessRules(IGlobalSettingRepository globalSettingRepository, ILocalizationService localizationService)
    {
        _globalSettingRepository = globalSettingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GlobalSettingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GlobalSettingShouldExistWhenSelected(GlobalSetting? globalSetting)
    {
        if (globalSetting == null)
            await throwBusinessException(GlobalSettingsBusinessMessages.GlobalSettingNotExists);
    }

    public async Task GlobalSettingIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        GlobalSetting? globalSetting = await _globalSettingRepository.GetAsync(
            predicate: gs => gs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GlobalSettingShouldExistWhenSelected(globalSetting);
    }

    // There should be only one global setting in the database
    public async Task GlobalSettingShouldBeUnique()
    {
        int globalSettingCount = await _globalSettingRepository.GetAsyncCount();
        if (globalSettingCount > 0)
            await throwBusinessException(GlobalSettingsBusinessMessages.GlobalSettingShouldBeUnique);
    }
}