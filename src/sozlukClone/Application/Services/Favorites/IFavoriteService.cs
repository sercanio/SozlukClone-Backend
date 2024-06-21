using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Favorites;

public interface IFavoriteService
{
    Task<Favorite?> GetAsync(
        Expression<Func<Favorite, bool>> predicate,
        Func<IQueryable<Favorite>, IIncludableQueryable<Favorite, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Favorite>?> GetListAsync(
        Expression<Func<Favorite, bool>>? predicate = null,
        Func<IQueryable<Favorite>, IOrderedQueryable<Favorite>>? orderBy = null,
        Func<IQueryable<Favorite>, IIncludableQueryable<Favorite, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Favorite> AddAsync(Favorite favorite);
    Task<Favorite> UpdateAsync(Favorite favorite);
    Task<Favorite> DeleteAsync(Favorite favorite, bool permanent = false);
}
