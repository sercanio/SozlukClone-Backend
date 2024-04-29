using Application.Features.LoginAudits.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LoginAudits;

public class LoginAuditManager : ILoginAuditService
{
    private readonly ILoginAuditRepository _loginAuditRepository;
    private readonly LoginAuditBusinessRules _loginAuditBusinessRules;

    public LoginAuditManager(ILoginAuditRepository loginAuditRepository, LoginAuditBusinessRules loginAuditBusinessRules)
    {
        _loginAuditRepository = loginAuditRepository;
        _loginAuditBusinessRules = loginAuditBusinessRules;
    }

    public LoginAuditManager()
    {
    }

    public async Task<LoginAudit?> GetAsync(
        Expression<Func<LoginAudit, bool>> predicate,
        Func<IQueryable<LoginAudit>, IIncludableQueryable<LoginAudit, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LoginAudit? loginAudit = await _loginAuditRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return loginAudit;
    }

    public async Task<IPaginate<LoginAudit>?> GetListAsync(
        Expression<Func<LoginAudit, bool>>? predicate = null,
        Func<IQueryable<LoginAudit>, IOrderedQueryable<LoginAudit>>? orderBy = null,
        Func<IQueryable<LoginAudit>, IIncludableQueryable<LoginAudit, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LoginAudit> loginAuditList = await _loginAuditRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return loginAuditList;
    }

    public async Task<LoginAudit> AddAsync(LoginAudit loginAudit)
    {
        LoginAudit addedLoginAudit = await _loginAuditRepository.AddAsync(loginAudit);

        return addedLoginAudit;
    }

    public async Task<LoginAudit> UpdateAsync(LoginAudit loginAudit)
    {
        LoginAudit updatedLoginAudit = await _loginAuditRepository.UpdateAsync(loginAudit);

        return updatedLoginAudit;
    }

    public async Task<LoginAudit> DeleteAsync(LoginAudit loginAudit, bool permanent = false)
    {
        LoginAudit deletedLoginAudit = await _loginAuditRepository.DeleteAsync(loginAudit);

        return deletedLoginAudit;
    }
}
