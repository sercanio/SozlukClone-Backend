using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.AuthorGroupUserOperationClaims;

public interface IAuthorGroupUserOperationClaimService
{
    Task<AuthorGroupUserOperationClaim?> GetAsync(
        Expression<Func<AuthorGroupUserOperationClaim, bool>> predicate,
        Func<IQueryable<AuthorGroupUserOperationClaim>, IIncludableQueryable<AuthorGroupUserOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AuthorGroupUserOperationClaim>?> GetListAsync(
        Expression<Func<AuthorGroupUserOperationClaim, bool>>? predicate = null,
        Func<IQueryable<AuthorGroupUserOperationClaim>, IOrderedQueryable<AuthorGroupUserOperationClaim>>? orderBy = null,
        Func<IQueryable<AuthorGroupUserOperationClaim>, IIncludableQueryable<AuthorGroupUserOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AuthorGroupUserOperationClaim> AddAsync(AuthorGroupUserOperationClaim authorGroupUserOperationClaim);
    Task<AuthorGroupUserOperationClaim> UpdateAsync(AuthorGroupUserOperationClaim authorGroupUserOperationClaim);
    Task<AuthorGroupUserOperationClaim> DeleteAsync(AuthorGroupUserOperationClaim authorGroupUserOperationClaim, bool permanent = false);
}
