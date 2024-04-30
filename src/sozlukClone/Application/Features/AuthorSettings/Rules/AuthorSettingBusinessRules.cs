using Application.Features.AuthorSettings.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.AuthorSettings.Rules;

public class AuthorSettingBusinessRules : BaseBusinessRules
{
    private readonly IAuthorSettingRepository _authorSettingRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorSettingBusinessRules(IAuthorSettingRepository authorSettingRepository, ILocalizationService localizationService)
    {
        _authorSettingRepository = authorSettingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorSettingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorSettingShouldExistWhenSelected(AuthorSetting? authorSetting)
    {
        if (authorSetting == null)
            await throwBusinessException(AuthorSettingsBusinessMessages.AuthorSettingNotExists);
    }

    public async Task AuthorSettingIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        AuthorSetting? authorSetting = await _authorSettingRepository.GetAsync(
            predicate: ast => ast.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorSettingShouldExistWhenSelected(authorSetting);
    }
}