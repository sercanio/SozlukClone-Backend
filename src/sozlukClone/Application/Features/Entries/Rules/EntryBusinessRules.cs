using Application.Features.Entries.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Entries.Rules;

public class EntryBusinessRules : BaseBusinessRules
{
    private readonly IEntryRepository _entryRepository;
    private readonly ILocalizationService _localizationService;

    public EntryBusinessRules(IEntryRepository entryRepository, ILocalizationService localizationService)
    {
        _entryRepository = entryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EntriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EntryShouldExistWhenSelected(Entry? entry)
    {
        if (entry == null)
            await throwBusinessException(EntriesBusinessMessages.EntryNotExists);
    }

    public async Task EntryIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        Entry? entry = await _entryRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EntryShouldExistWhenSelected(entry);
    }
}