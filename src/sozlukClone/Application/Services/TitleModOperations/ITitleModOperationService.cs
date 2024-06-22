using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleModOperations;

public interface ITitleModOperationService
{
    Task<TitleModOperation?> GetAsync(
        Expression<Func<TitleModOperation, bool>> predicate,
        Func<IQueryable<TitleModOperation>, IIncludableQueryable<TitleModOperation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TitleModOperation>?> GetListAsync(
        Expression<Func<TitleModOperation, bool>>? predicate = null,
        Func<IQueryable<TitleModOperation>, IOrderedQueryable<TitleModOperation>>? orderBy = null,
        Func<IQueryable<TitleModOperation>, IIncludableQueryable<TitleModOperation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TitleModOperation> AddAsync(TitleModOperation titleModOperation);
    Task<TitleModOperation> UpdateAsync(TitleModOperation titleModOperation);
    Task<TitleModOperation> DeleteAsync(TitleModOperation titleModOperation, bool permanent = false);
}
