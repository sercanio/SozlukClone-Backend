using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorGroups;

public interface IAuthorGroupService
{
    Task<AuthorGroup?> GetAsync(
        Expression<Func<AuthorGroup, bool>> predicate,
        Func<IQueryable<AuthorGroup>, IIncludableQueryable<AuthorGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AuthorGroup>?> GetListAsync(
        Expression<Func<AuthorGroup, bool>>? predicate = null,
        Func<IQueryable<AuthorGroup>, IOrderedQueryable<AuthorGroup>>? orderBy = null,
        Func<IQueryable<AuthorGroup>, IIncludableQueryable<AuthorGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AuthorGroup> AddAsync(AuthorGroup authorGroup);
    Task<AuthorGroup> UpdateAsync(AuthorGroup authorGroup);
    Task<AuthorGroup> DeleteAsync(AuthorGroup authorGroup, bool permanent = false);
}
