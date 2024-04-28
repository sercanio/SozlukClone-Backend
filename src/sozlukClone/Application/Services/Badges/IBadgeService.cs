using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Badges;

public interface IBadgeService
{
    Task<Badge?> GetAsync(
        Expression<Func<Badge, bool>> predicate,
        Func<IQueryable<Badge>, IIncludableQueryable<Badge, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Badge>?> GetListAsync(
        Expression<Func<Badge, bool>>? predicate = null,
        Func<IQueryable<Badge>, IOrderedQueryable<Badge>>? orderBy = null,
        Func<IQueryable<Badge>, IIncludableQueryable<Badge, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Badge> AddAsync(Badge badge);
    Task<Badge> UpdateAsync(Badge badge);
    Task<Badge> DeleteAsync(Badge badge, bool permanent = false);
}
