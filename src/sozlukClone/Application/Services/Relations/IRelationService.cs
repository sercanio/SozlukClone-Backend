using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Relations;

public interface IRelationService
{
    Task<Relation?> GetAsync(
        Expression<Func<Relation, bool>> predicate,
        Func<IQueryable<Relation>, IIncludableQueryable<Relation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Relation>?> GetListAsync(
        Expression<Func<Relation, bool>>? predicate = null,
        Func<IQueryable<Relation>, IOrderedQueryable<Relation>>? orderBy = null,
        Func<IQueryable<Relation>, IIncludableQueryable<Relation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Relation> AddAsync(Relation relation);
    Task<Relation> UpdateAsync(Relation relation);
    Task<Relation> DeleteAsync(Relation relation, bool permanent = false);
}
