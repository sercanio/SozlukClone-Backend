using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PenaltyTypes;

public interface IPenaltyTypeService
{
    Task<PenaltyType?> GetAsync(
        Expression<Func<PenaltyType, bool>> predicate,
        Func<IQueryable<PenaltyType>, IIncludableQueryable<PenaltyType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PenaltyType>?> GetListAsync(
        Expression<Func<PenaltyType, bool>>? predicate = null,
        Func<IQueryable<PenaltyType>, IOrderedQueryable<PenaltyType>>? orderBy = null,
        Func<IQueryable<PenaltyType>, IIncludableQueryable<PenaltyType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PenaltyType> AddAsync(PenaltyType penaltyType);
    Task<PenaltyType> UpdateAsync(PenaltyType penaltyType);
    Task<PenaltyType> DeleteAsync(PenaltyType penaltyType, bool permanent = false);
}
