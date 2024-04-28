using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Followings;

public interface IFollowingService
{
    Task<Following?> GetAsync(
        Expression<Func<Following, bool>> predicate,
        Func<IQueryable<Following>, IIncludableQueryable<Following, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Following>?> GetListAsync(
        Expression<Func<Following, bool>>? predicate = null,
        Func<IQueryable<Following>, IOrderedQueryable<Following>>? orderBy = null,
        Func<IQueryable<Following>, IIncludableQueryable<Following, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Following> AddAsync(Following following);
    Task<Following> UpdateAsync(Following following);
    Task<Following> DeleteAsync(Following following, bool permanent = false);
}
