using Application.Features.TitleModOperations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TitleModOperations.Rules;

public class TitleModOperationBusinessRules : BaseBusinessRules
{
    private readonly ITitleModOperationRepository _titleModOperationRepository;
    private readonly ILocalizationService _localizationService;

    public TitleModOperationBusinessRules(ITitleModOperationRepository titleModOperationRepository, ILocalizationService localizationService)
    {
        _titleModOperationRepository = titleModOperationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TitleModOperationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TitleModOperationShouldExistWhenSelected(TitleModOperation? titleModOperation)
    {
        if (titleModOperation == null)
            await throwBusinessException(TitleModOperationsBusinessMessages.TitleModOperationNotExists);
    }

    public async Task TitleModOperationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TitleModOperation? titleModOperation = await _titleModOperationRepository.GetAsync(
            predicate: tmo => tmo.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TitleModOperationShouldExistWhenSelected(titleModOperation);
    }
}