using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorFollowings;

public interface IAuthorFollowingService
{
    Task<AuthorFollowing?> GetAsync(
        Expression<Func<AuthorFollowing, bool>> predicate,
        Func<IQueryable<AuthorFollowing>, IIncludableQueryable<AuthorFollowing, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AuthorFollowing>?> GetListAsync(
        Expression<Func<AuthorFollowing, bool>>? predicate = null,
        Func<IQueryable<AuthorFollowing>, IOrderedQueryable<AuthorFollowing>>? orderBy = null,
        Func<IQueryable<AuthorFollowing>, IIncludableQueryable<AuthorFollowing, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AuthorFollowing> AddAsync(AuthorFollowing authorFollowing);
    Task<AuthorFollowing> UpdateAsync(AuthorFollowing authorFollowing);
    Task<AuthorFollowing> DeleteAsync(AuthorFollowing authorFollowing, bool permanent = false);
}
