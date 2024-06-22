using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorBlockings;

public interface IAuthorBlockingService
{
    Task<AuthorBlocking?> GetAsync(
        Expression<Func<AuthorBlocking, bool>> predicate,
        Func<IQueryable<AuthorBlocking>, IIncludableQueryable<AuthorBlocking, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AuthorBlocking>?> GetListAsync(
        Expression<Func<AuthorBlocking, bool>>? predicate = null,
        Func<IQueryable<AuthorBlocking>, IOrderedQueryable<AuthorBlocking>>? orderBy = null,
        Func<IQueryable<AuthorBlocking>, IIncludableQueryable<AuthorBlocking, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AuthorBlocking> AddAsync(AuthorBlocking authorBlocking);
    Task<AuthorBlocking> UpdateAsync(AuthorBlocking authorBlocking);
    Task<AuthorBlocking> DeleteAsync(AuthorBlocking authorBlocking, bool permanent = false);
}
