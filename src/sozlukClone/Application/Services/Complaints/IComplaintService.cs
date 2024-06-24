using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Complaints;

public interface IComplaintService
{
    Task<Complaint?> GetAsync(
        Expression<Func<Complaint, bool>> predicate,
        Func<IQueryable<Complaint>, IIncludableQueryable<Complaint, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Complaint>?> GetListAsync(
        Expression<Func<Complaint, bool>>? predicate = null,
        Func<IQueryable<Complaint>, IOrderedQueryable<Complaint>>? orderBy = null,
        Func<IQueryable<Complaint>, IIncludableQueryable<Complaint, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Complaint> AddAsync(Complaint complaint);
    Task<Complaint> UpdateAsync(Complaint complaint);
    Task<Complaint> DeleteAsync(Complaint complaint, bool permanent = false);
}
