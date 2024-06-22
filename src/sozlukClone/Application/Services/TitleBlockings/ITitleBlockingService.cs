using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleBlockings;

public interface ITitleBlockingService
{
    Task<TitleBlocking?> GetAsync(
        Expression<Func<TitleBlocking, bool>> predicate,
        Func<IQueryable<TitleBlocking>, IIncludableQueryable<TitleBlocking, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TitleBlocking>?> GetListAsync(
        Expression<Func<TitleBlocking, bool>>? predicate = null,
        Func<IQueryable<TitleBlocking>, IOrderedQueryable<TitleBlocking>>? orderBy = null,
        Func<IQueryable<TitleBlocking>, IIncludableQueryable<TitleBlocking, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TitleBlocking> AddAsync(TitleBlocking titleBlocking);
    Task<TitleBlocking> UpdateAsync(TitleBlocking titleBlocking);
    Task<TitleBlocking> DeleteAsync(TitleBlocking titleBlocking, bool permanent = false);
}
