using Application.Features.Dislikes.Constants;
using Application.Services.Entries;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Dislikes.Rules;

public class DislikeBusinessRules : BaseBusinessRules
{
    private readonly IDislikeRepository _dislikeRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IEntryService _entryService;

    public DislikeBusinessRules(IDislikeRepository dislikeRepository, ILocalizationService localizationService, IEntryService entryService)
    {
        _dislikeRepository = dislikeRepository;
        _localizationService = localizationService;
        _entryService = entryService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DislikesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DislikeShouldExistWhenSelected(Dislike? dislike)
    {
        if (dislike == null)
            await throwBusinessException(DislikesBusinessMessages.DislikeNotExists);
    }

    public async Task DislikeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Dislike? dislike = await _dislikeRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DislikeShouldExistWhenSelected(dislike);
    }

    public async Task DislikeShouldGivenToOtherAuthors(int entryId, int authorId, CancellationToken cancellationToken)
    {
        Entry? entry = await _entryService.GetAsync(predicate: e => e.Id == entryId);

        if (entry?.AuthorId == authorId)
        {
            await throwBusinessException(DislikesBusinessMessages.AuthorRatesItself);

        }
    }
}