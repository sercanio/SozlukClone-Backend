using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Entries;

public interface IEntryService
{
    Task<Entry?> GetAsync(
        Expression<Func<Entry, bool>> predicate,
        Func<IQueryable<Entry>, IIncludableQueryable<Entry, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Entry>?> GetListAsync(
        Expression<Func<Entry, bool>>? predicate = null,
        Func<IQueryable<Entry>, IOrderedQueryable<Entry>>? orderBy = null,
        Func<IQueryable<Entry>, IIncludableQueryable<Entry, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Entry> AddAsync(Entry entry);
    Task<Entry> UpdateAsync(Entry entry);
    Task<Entry> DeleteAsync(Entry entry, bool permanent = false);
}
