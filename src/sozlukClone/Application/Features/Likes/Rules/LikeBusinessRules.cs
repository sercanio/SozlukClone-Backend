using Application.Features.Likes.Constants;
using Application.Services.Entries;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Like = Domain.Entities.Like;

namespace Application.Features.Likes.Rules;

public class LikeBusinessRules : BaseBusinessRules
{
    private readonly ILikeRepository _likeRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IEntryService _entryService;

    public LikeBusinessRules(ILikeRepository likeRepository, ILocalizationService localizationService, IEntryService entryService)
    {
        _likeRepository = likeRepository;
        _localizationService = localizationService;
        _entryService = entryService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LikesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LikeShouldExistWhenSelected(Like? like)
    {
        if (like == null)
            await throwBusinessException(LikesBusinessMessages.LikeNotExists);
    }

    public async Task LikeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Like? like = await _likeRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LikeShouldExistWhenSelected(like);
    }

    public async Task LikeShouldGivenToOtherAuthors(int entryId, int authorId, CancellationToken cancellationToken)
    {
        Entry? entry = await _entryService.GetAsync(predicate: e => e.Id == entryId);

        if (entry?.AuthorId == authorId)
        {
            await throwBusinessException(LikesBusinessMessages.AuthorRatesItself);

        }
    }
}