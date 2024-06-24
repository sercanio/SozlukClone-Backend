using Application.Factories.LikeServiceFactory;
using Application.Features.Likes.Constants;
using Application.Services.Dislikes;
using Application.Services.Entries;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Likes.Rules;

public class LikeBusinessRules : BaseBusinessRules
{
    private readonly ILikeRepository _likeRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IEntryService _entryService;
    private readonly IDislikeServiceFactory _dislikeServiceFactory;

    public LikeBusinessRules(ILikeRepository likeRepository, ILocalizationService localizationService, IEntryService entryService, IDislikeServiceFactory dislikeServiceFactory)
    {
        _likeRepository = likeRepository;
        _localizationService = localizationService;
        _entryService = entryService;
        _dislikeServiceFactory = dislikeServiceFactory;
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

    public async Task LikeIdShouldExistWhenSelected(Guid Id, CancellationToken cancellationToken)
    {
        Like? like = await _likeRepository.GetAsync(
            predicate: l => l.Id == Id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LikeShouldExistWhenSelected(like);
    }

    public async Task LikeShouldNotOwnedByEntryAuthorWhenSelected(Like like, CancellationToken cancellationToken)
    {
        Entry? entry = await _entryService.GetAsync(predicate: e => e.Id == like.EntryId);

        if (entry?.AuthorId == like.AuthorId)
        {
            await throwBusinessException(LikesBusinessMessages.AuthorRatesItself);
        }
    }

    public async Task LikeShouldNotDuplicatedWhenInserted(Like like, CancellationToken cancellationToken)
    {
        Like? existingLike = await _likeRepository.GetAsync(
            predicate: l => l.EntryId == like.EntryId && l.AuthorId == like.AuthorId,
            cancellationToken: cancellationToken
        );

        if (existingLike != null)
        {
            await throwBusinessException(LikesBusinessMessages.LikeAlreadyExists);
        }
    }

    public async Task DislikeShouldNotExistWhenLikeInserted(Like like, CancellationToken cancellationToken)
    {
        IDislikeService dislikeService = _dislikeServiceFactory.Create();

        Dislike? existingDislike = await dislikeService.GetAsync(
            predicate: d => d.EntryId == like.EntryId && d.AuthorId == like.AuthorId,
            cancellationToken: cancellationToken);

        if (existingDislike != null)
        {
            await throwBusinessException(LikesBusinessMessages.DislikeExists);
        }
    }
}