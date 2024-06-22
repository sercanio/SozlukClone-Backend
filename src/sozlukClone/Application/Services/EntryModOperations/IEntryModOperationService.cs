using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EntryModOperations;

public interface IEntryModOperationService
{
    Task<EntryModOperation?> GetAsync(
        Expression<Func<EntryModOperation, bool>> predicate,
        Func<IQueryable<EntryModOperation>, IIncludableQueryable<EntryModOperation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EntryModOperation>?> GetListAsync(
        Expression<Func<EntryModOperation, bool>>? predicate = null,
        Func<IQueryable<EntryModOperation>, IOrderedQueryable<EntryModOperation>>? orderBy = null,
        Func<IQueryable<EntryModOperation>, IIncludableQueryable<EntryModOperation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EntryModOperation> AddAsync(EntryModOperation entryModOperation);
    Task<EntryModOperation> UpdateAsync(EntryModOperation entryModOperation);
    Task<EntryModOperation> DeleteAsync(EntryModOperation entryModOperation, bool permanent = false);
}
