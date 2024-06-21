using Application.Features.Favorites.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Favorites;

public class FavoriteManager : IFavoriteService
{
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly FavoriteBusinessRules _favoriteBusinessRules;

    public FavoriteManager(IFavoriteRepository favoriteRepository, FavoriteBusinessRules favoriteBusinessRules)
    {
        _favoriteRepository = favoriteRepository;
        _favoriteBusinessRules = favoriteBusinessRules;
    }

    public async Task<Favorite?> GetAsync(
        Expression<Func<Favorite, bool>> predicate,
        Func<IQueryable<Favorite>, IIncludableQueryable<Favorite, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Favorite? favorite = await _favoriteRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return favorite;
    }

    public async Task<IPaginate<Favorite>?> GetListAsync(
        Expression<Func<Favorite, bool>>? predicate = null,
        Func<IQueryable<Favorite>, IOrderedQueryable<Favorite>>? orderBy = null,
        Func<IQueryable<Favorite>, IIncludableQueryable<Favorite, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Favorite> favoriteList = await _favoriteRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return favoriteList;
    }

    public async Task<Favorite> AddAsync(Favorite favorite)
    {
        Favorite addedFavorite = await _favoriteRepository.AddAsync(favorite);

        return addedFavorite;
    }

    public async Task<Favorite> UpdateAsync(Favorite favorite)
    {
        Favorite updatedFavorite = await _favoriteRepository.UpdateAsync(favorite);

        return updatedFavorite;
    }

    public async Task<Favorite> DeleteAsync(Favorite favorite, bool permanent = false)
    {
        Favorite deletedFavorite = await _favoriteRepository.DeleteAsync(favorite);

        return deletedFavorite;
    }
}
