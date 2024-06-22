using Application.Features.EntryModOperations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.EntryModOperations.Rules;

public class EntryModOperationBusinessRules : BaseBusinessRules
{
    private readonly IEntryModOperationRepository _entryModOperationRepository;
    private readonly ILocalizationService _localizationService;

    public EntryModOperationBusinessRules(IEntryModOperationRepository entryModOperationRepository, ILocalizationService localizationService)
    {
        _entryModOperationRepository = entryModOperationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EntryModOperationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EntryModOperationShouldExistWhenSelected(EntryModOperation? entryModOperation)
    {
        if (entryModOperation == null)
            await throwBusinessException(EntryModOperationsBusinessMessages.EntryModOperationNotExists);
    }

    public async Task EntryModOperationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        EntryModOperation? entryModOperation = await _entryModOperationRepository.GetAsync(
            predicate: emo => emo.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EntryModOperationShouldExistWhenSelected(entryModOperation);
    }
}