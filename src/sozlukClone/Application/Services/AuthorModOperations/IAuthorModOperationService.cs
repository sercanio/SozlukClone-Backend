using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorModOperations;

public interface IAuthorModOperationService
{
    Task<AuthorModOperation?> GetAsync(
        Expression<Func<AuthorModOperation, bool>> predicate,
        Func<IQueryable<AuthorModOperation>, IIncludableQueryable<AuthorModOperation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AuthorModOperation>?> GetListAsync(
        Expression<Func<AuthorModOperation, bool>>? predicate = null,
        Func<IQueryable<AuthorModOperation>, IOrderedQueryable<AuthorModOperation>>? orderBy = null,
        Func<IQueryable<AuthorModOperation>, IIncludableQueryable<AuthorModOperation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AuthorModOperation> AddAsync(AuthorModOperation authorModOperation);
    Task<AuthorModOperation> UpdateAsync(AuthorModOperation authorModOperation);
    Task<AuthorModOperation> DeleteAsync(AuthorModOperation authorModOperation, bool permanent = false);
}
