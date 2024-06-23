using Application.Features.Dislikes.Constants;
using Application.Services.Entries;
using Application.Services.Favorites;
using Application.Services.Likes;
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
    private readonly ILikeService _likeService;
    private readonly IFavoriteService _favoriteService;

    public DislikeBusinessRules(IDislikeRepository dislikeRepository, ILocalizationService localizationService, IEntryService entryService, ILikeRepository likeRepository, IFavoriteService favoriteService, ILikeService likeService)
    {
        _dislikeRepository = dislikeRepository;
        _localizationService = localizationService;
        _entryService = entryService;
        _likeService = likeService;
        _favoriteService = favoriteService;
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

    public async Task DisikeShouldNotOwnedByEntryAuthorWhenSelected(Dislike dislike, CancellationToken cancellationToken)
    {
        Entry? entry = await _entryService.GetAsync(predicate: e => e.Id == dislike.EntryId);

        if (entry?.AuthorId == dislike.AuthorId)
        {
            await throwBusinessException(DislikesBusinessMessages.AuthorRatesItself);
        }
    }

    public async Task DisikeShouldNotDuplicatedWhenInserted(Dislike like, CancellationToken cancellationToken)
    {
        Dislike? existingDisike = await _dislikeRepository.GetAsync(
           predicate: l => l.EntryId == like.EntryId && l.AuthorId == like.AuthorId
           );

        if (existingDisike != null)
        {
            await throwBusinessException(DislikesBusinessMessages.DislikeAlreadyExists);
        }
    }

    public async Task LikeShouldNotExistWhenDislikeInserted(Dislike dislike, CancellationToken cancellationToken)
    {
        Like? existingLike = await _likeService.GetAsync(
                predicate: l => l.EntryId == dislike.EntryId && l.AuthorId == dislike.AuthorId,
                cancellationToken: cancellationToken);

        if (existingLike != null)
        {
            await throwBusinessException(DislikesBusinessMessages.LikeExists);
        }
    }

    public async Task FavoriteShouldNotExistWhenDislikeInserted(Dislike dislike, CancellationToken cancellationToken)
    {
        Favorite? existingFavorite = await _favoriteService.GetAsync(
                predicate: f => f.EntryId == dislike.EntryId && f.AuthorId == dislike.AuthorId,
                cancellationToken: cancellationToken);

        if (existingFavorite != null)
        {
            await throwBusinessException(DislikesBusinessMessages.FavoriteExists);
        }
    }
}