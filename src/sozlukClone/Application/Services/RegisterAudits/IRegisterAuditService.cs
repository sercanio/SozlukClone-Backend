using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RegisterAudits;

public interface IRegisterAuditService
{
    Task<RegisterAudit?> GetAsync(
        Expression<Func<RegisterAudit, bool>> predicate,
        Func<IQueryable<RegisterAudit>, IIncludableQueryable<RegisterAudit, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RegisterAudit>?> GetListAsync(
        Expression<Func<RegisterAudit, bool>>? predicate = null,
        Func<IQueryable<RegisterAudit>, IOrderedQueryable<RegisterAudit>>? orderBy = null,
        Func<IQueryable<RegisterAudit>, IIncludableQueryable<RegisterAudit, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RegisterAudit> AddAsync(RegisterAudit registerAudit);
    Task<RegisterAudit> UpdateAsync(RegisterAudit registerAudit);
    Task<RegisterAudit> DeleteAsync(RegisterAudit registerAudit, bool permanent = false);
}
