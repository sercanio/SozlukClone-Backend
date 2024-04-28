using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Titles;

public interface ITitleService
{
    Task<Title?> GetAsync(
        Expression<Func<Title, bool>> predicate,
        Func<IQueryable<Title>, IIncludableQueryable<Title, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Title>?> GetListAsync(
        Expression<Func<Title, bool>>? predicate = null,
        Func<IQueryable<Title>, IOrderedQueryable<Title>>? orderBy = null,
        Func<IQueryable<Title>, IIncludableQueryable<Title, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Title> AddAsync(Title title);
    Task<Title> UpdateAsync(Title title);
    Task<Title> DeleteAsync(Title title, bool permanent = false);
}
