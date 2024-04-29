using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LoginAudits;

public interface ILoginAuditService
{
    Task<LoginAudit?> GetAsync(
        Expression<Func<LoginAudit, bool>> predicate,
        Func<IQueryable<LoginAudit>, IIncludableQueryable<LoginAudit, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LoginAudit>?> GetListAsync(
        Expression<Func<LoginAudit, bool>>? predicate = null,
        Func<IQueryable<LoginAudit>, IOrderedQueryable<LoginAudit>>? orderBy = null,
        Func<IQueryable<LoginAudit>, IIncludableQueryable<LoginAudit, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LoginAudit> AddAsync(LoginAudit loginAudit);
    Task<LoginAudit> UpdateAsync(LoginAudit loginAudit);
    Task<LoginAudit> DeleteAsync(LoginAudit loginAudit, bool permanent = false);
}
