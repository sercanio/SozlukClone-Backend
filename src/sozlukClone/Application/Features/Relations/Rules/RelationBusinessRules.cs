using Application.Features.Relations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Relations.Rules;

public class RelationBusinessRules : BaseBusinessRules
{
    private readonly IRelationRepository _relationRepository;
    private readonly ILocalizationService _localizationService;

    public RelationBusinessRules(IRelationRepository relationRepository, ILocalizationService localizationService)
    {
        _relationRepository = relationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RelationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RelationShouldExistWhenSelected(Relation? relation)
    {
        if (relation == null)
            await throwBusinessException(RelationsBusinessMessages.RelationNotExists);
    }

    public async Task RelationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Relation? relation = await _relationRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RelationShouldExistWhenSelected(relation);
    }
}