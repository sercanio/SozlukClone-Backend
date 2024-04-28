using Application.Features.PenaltyTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PenaltyTypes.Rules;

public class PenaltyTypeBusinessRules : BaseBusinessRules
{
    private readonly IPenaltyTypeRepository _penaltyTypeRepository;
    private readonly ILocalizationService _localizationService;

    public PenaltyTypeBusinessRules(IPenaltyTypeRepository penaltyTypeRepository, ILocalizationService localizationService)
    {
        _penaltyTypeRepository = penaltyTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PenaltyTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PenaltyTypeShouldExistWhenSelected(PenaltyType? penaltyType)
    {
        if (penaltyType == null)
            await throwBusinessException(PenaltyTypesBusinessMessages.PenaltyTypeNotExists);
    }

    public async Task PenaltyTypeIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        PenaltyType? penaltyType = await _penaltyTypeRepository.GetAsync(
            predicate: pt => pt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PenaltyTypeShouldExistWhenSelected(penaltyType);
    }
}