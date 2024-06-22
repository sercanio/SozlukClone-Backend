using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleFollowings;

public interface ITitleFollowingService
{
    Task<TitleFollowing?> GetAsync(
        Expression<Func<TitleFollowing, bool>> predicate,
        Func<IQueryable<TitleFollowing>, IIncludableQueryable<TitleFollowing, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TitleFollowing>?> GetListAsync(
        Expression<Func<TitleFollowing, bool>>? predicate = null,
        Func<IQueryable<TitleFollowing>, IOrderedQueryable<TitleFollowing>>? orderBy = null,
        Func<IQueryable<TitleFollowing>, IIncludableQueryable<TitleFollowing, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TitleFollowing> AddAsync(TitleFollowing titleFollowing);
    Task<TitleFollowing> UpdateAsync(TitleFollowing titleFollowing);
    Task<TitleFollowing> DeleteAsync(TitleFollowing titleFollowing, bool permanent = false);
}
