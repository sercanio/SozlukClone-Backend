using Application.Features.AuthorGroupUserOperationClaims.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.AuthorGroupUserOperationClaims;

public class AuthorGroupUserOperationClaimManager : IAuthorGroupUserOperationClaimService
{
    private readonly IAuthorGroupUserOperationClaimRepository _authorGroupUserOperationClaimRepository;
    private readonly AuthorGroupUserOperationClaimBusinessRules _authorGroupUserOperationClaimBusinessRules;

    public AuthorGroupUserOperationClaimManager(IAuthorGroupUserOperationClaimRepository authorGroupUserOperationClaimRepository, AuthorGroupUserOperationClaimBusinessRules authorGroupUserOperationClaimBusinessRules)
    {
        _authorGroupUserOperationClaimRepository = authorGroupUserOperationClaimRepository;
        _authorGroupUserOperationClaimBusinessRules = authorGroupUserOperationClaimBusinessRules;
    }

    public AuthorGroupUserOperationClaimManager()
    {
    }

    public async Task<AuthorGroupUserOperationClaim?> GetAsync(
        Expression<Func<AuthorGroupUserOperationClaim, bool>> predicate,
        Func<IQueryable<AuthorGroupUserOperationClaim>, IIncludableQueryable<AuthorGroupUserOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AuthorGroupUserOperationClaim? authorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return authorGroupUserOperationClaim;
    }

    public async Task<IPaginate<AuthorGroupUserOperationClaim>?> GetListAsync(
        Expression<Func<AuthorGroupUserOperationClaim, bool>>? predicate = null,
        Func<IQueryable<AuthorGroupUserOperationClaim>, IOrderedQueryable<AuthorGroupUserOperationClaim>>? orderBy = null,
        Func<IQueryable<AuthorGroupUserOperationClaim>, IIncludableQueryable<AuthorGroupUserOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AuthorGroupUserOperationClaim> authorGroupUserOperationClaimList = await _authorGroupUserOperationClaimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorGroupUserOperationClaimList;
    }

    public async Task<AuthorGroupUserOperationClaim> AddAsync(AuthorGroupUserOperationClaim authorGroupUserOperationClaim)
    {
        AuthorGroupUserOperationClaim addedAuthorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.AddAsync(authorGroupUserOperationClaim);

        return addedAuthorGroupUserOperationClaim;
    }

    public async Task<AuthorGroupUserOperationClaim> UpdateAsync(AuthorGroupUserOperationClaim authorGroupUserOperationClaim)
    {
        AuthorGroupUserOperationClaim updatedAuthorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.UpdateAsync(authorGroupUserOperationClaim);

        return updatedAuthorGroupUserOperationClaim;
    }

    public async Task<AuthorGroupUserOperationClaim> DeleteAsync(AuthorGroupUserOperationClaim authorGroupUserOperationClaim, bool permanent = false)
    {
        AuthorGroupUserOperationClaim deletedAuthorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.DeleteAsync(authorGroupUserOperationClaim, permanent);

        return deletedAuthorGroupUserOperationClaim;
    }
}
