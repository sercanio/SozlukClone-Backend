using Application.Features.Favorites.Constants;
using Application.Services.Entries;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Favorites.Rules;

public class FavoriteBusinessRules : BaseBusinessRules
{
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IEntryService _entryService;
    private readonly IDislikeRepository _dislikeRepository;

    public FavoriteBusinessRules(IFavoriteRepository favoriteRepository, ILocalizationService localizationService, IEntryService entryService, IDislikeRepository dislikeRepository)
    {
        _favoriteRepository = favoriteRepository;
        _localizationService = localizationService;
        _entryService = entryService;
        _dislikeRepository = dislikeRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FavoritesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FavoriteShouldExistWhenSelected(Favorite? favorite)
    {
        if (favorite == null)
            await throwBusinessException(FavoritesBusinessMessages.FavoriteNotExists);
    }

    public async Task FavoriteIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Favorite? favorite = await _favoriteRepository.GetAsync(
            predicate: f => f.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FavoriteShouldExistWhenSelected(favorite);
    }

    public async Task FavoriteShouldNotOwnedByEntryAuthorWhenSelected(Favorite favorite, CancellationToken cancellationToken)
    {
        Entry? entry = await _entryService.GetAsync(predicate: e => e.Id == favorite.EntryId);

        if (entry?.AuthorId == favorite.AuthorId)
        {
            await throwBusinessException(FavoritesBusinessMessages.AuthorRatesItself);

        }
    }

    public async Task FavoriteShouldNotDuplicatedWhenInserted(Favorite favorite, CancellationToken cancellationToken)
    {
        Favorite? existingFavorite = await _favoriteRepository.GetAsync(
            predicate: f => f.EntryId == favorite.EntryId && f.AuthorId == favorite.AuthorId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (existingFavorite != null)
        {
            await throwBusinessException(FavoritesBusinessMessages.FavoriteAlreadyExists);
        }
    }

    public async Task DislikeShouldNotExistWhenLikeInserted(Favorite favorite)
    {
        Dislike? existingDislike = await _dislikeRepository.GetAsync(
            predicate: d => d.EntryId == favorite.EntryId && d.AuthorId == favorite.AuthorId);

        if (existingDislike != null)
        {
            await throwBusinessException(FavoritesBusinessMessages.DislikeExists);
        }
    }
}