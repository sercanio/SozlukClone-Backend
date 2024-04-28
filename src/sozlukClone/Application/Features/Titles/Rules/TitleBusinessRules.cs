using Application.Features.Titles.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Titles.Rules;

public class TitleBusinessRules : BaseBusinessRules
{
    private readonly ITitleRepository _titleRepository;
    private readonly ILocalizationService _localizationService;

    public TitleBusinessRules(ITitleRepository titleRepository, ILocalizationService localizationService)
    {
        _titleRepository = titleRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TitlesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TitleShouldExistWhenSelected(Title? title)
    {
        if (title == null)
            await throwBusinessException(TitlesBusinessMessages.TitleNotExists);
    }

    public async Task TitleIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        Title? title = await _titleRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TitleShouldExistWhenSelected(title);
    }
}