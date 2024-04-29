using Application.Features.RegisterAudits.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RegisterAudits;

public class RegisterAuditManager : IRegisterAuditService
{
    private readonly IRegisterAuditRepository _registerAuditRepository;
    private readonly RegisterAuditBusinessRules _registerAuditBusinessRules;

    public RegisterAuditManager(IRegisterAuditRepository registerAuditRepository, RegisterAuditBusinessRules registerAuditBusinessRules)
    {
        _registerAuditRepository = registerAuditRepository;
        _registerAuditBusinessRules = registerAuditBusinessRules;
    }

    public RegisterAuditManager()
    {
    }

    public async Task<RegisterAudit?> GetAsync(
        Expression<Func<RegisterAudit, bool>> predicate,
        Func<IQueryable<RegisterAudit>, IIncludableQueryable<RegisterAudit, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RegisterAudit? registerAudit = await _registerAuditRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return registerAudit;
    }

    public async Task<IPaginate<RegisterAudit>?> GetListAsync(
        Expression<Func<RegisterAudit, bool>>? predicate = null,
        Func<IQueryable<RegisterAudit>, IOrderedQueryable<RegisterAudit>>? orderBy = null,
        Func<IQueryable<RegisterAudit>, IIncludableQueryable<RegisterAudit, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RegisterAudit> registerAuditList = await _registerAuditRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return registerAuditList;
    }

    public async Task<RegisterAudit> AddAsync(RegisterAudit registerAudit)
    {
        RegisterAudit addedRegisterAudit = await _registerAuditRepository.AddAsync(registerAudit);

        return addedRegisterAudit;
    }

    public async Task<RegisterAudit> UpdateAsync(RegisterAudit registerAudit)
    {
        RegisterAudit updatedRegisterAudit = await _registerAuditRepository.UpdateAsync(registerAudit);

        return updatedRegisterAudit;
    }

    public async Task<RegisterAudit> DeleteAsync(RegisterAudit registerAudit, bool permanent = false)
    {
        RegisterAudit deletedRegisterAudit = await _registerAuditRepository.DeleteAsync(registerAudit);

        return deletedRegisterAudit;
    }
}
