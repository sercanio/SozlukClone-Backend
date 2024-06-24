using Application.Features.Complaints.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Complaints;

public class ComplaintManager : IComplaintService
{
    private readonly IComplaintRepository _complaintRepository;
    private readonly ComplaintBusinessRules _complaintBusinessRules;

    public ComplaintManager(IComplaintRepository complaintRepository, ComplaintBusinessRules complaintBusinessRules)
    {
        _complaintRepository = complaintRepository;
        _complaintBusinessRules = complaintBusinessRules;
    }

    public async Task<Complaint?> GetAsync(
        Expression<Func<Complaint, bool>> predicate,
        Func<IQueryable<Complaint>, IIncludableQueryable<Complaint, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Complaint? complaint = await _complaintRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return complaint;
    }

    public async Task<IPaginate<Complaint>?> GetListAsync(
        Expression<Func<Complaint, bool>>? predicate = null,
        Func<IQueryable<Complaint>, IOrderedQueryable<Complaint>>? orderBy = null,
        Func<IQueryable<Complaint>, IIncludableQueryable<Complaint, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Complaint> complaintList = await _complaintRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return complaintList;
    }

    public async Task<Complaint> AddAsync(Complaint complaint)
    {
        Complaint addedComplaint = await _complaintRepository.AddAsync(complaint);

        return addedComplaint;
    }

    public async Task<Complaint> UpdateAsync(Complaint complaint)
    {
        Complaint updatedComplaint = await _complaintRepository.UpdateAsync(complaint);

        return updatedComplaint;
    }

    public async Task<Complaint> DeleteAsync(Complaint complaint, bool permanent = false)
    {
        Complaint deletedComplaint = await _complaintRepository.DeleteAsync(complaint);

        return deletedComplaint;
    }
}
