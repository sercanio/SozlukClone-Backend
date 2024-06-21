using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Dislikes;

public interface IDislikeService
{
    Task<Dislike?> GetAsync(
        Expression<Func<Dislike, bool>> predicate,
        Func<IQueryable<Dislike>, IIncludableQueryable<Dislike, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Dislike>?> GetListAsync(
        Expression<Func<Dislike, bool>>? predicate = null,
        Func<IQueryable<Dislike>, IOrderedQueryable<Dislike>>? orderBy = null,
        Func<IQueryable<Dislike>, IIncludableQueryable<Dislike, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Dislike> AddAsync(Dislike dislike);
    Task<Dislike> UpdateAsync(Dislike dislike);
    Task<Dislike> DeleteAsync(Dislike dislike, bool permanent = false);
}
