using Application.Features.AuthorBlockings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorBlockings;

public class AuthorBlockingManager : IAuthorBlockingService
{
    private readonly IAuthorBlockingRepository _authorBlockingRepository;
    private readonly AuthorBlockingBusinessRules _authorBlockingBusinessRules;

    public AuthorBlockingManager(IAuthorBlockingRepository authorBlockingRepository, AuthorBlockingBusinessRules authorBlockingBusinessRules)
    {
        _authorBlockingRepository = authorBlockingRepository;
        _authorBlockingBusinessRules = authorBlockingBusinessRules;
    }

    public async Task<AuthorBlocking?> GetAsync(
        Expression<Func<AuthorBlocking, bool>> predicate,
        Func<IQueryable<AuthorBlocking>, IIncludableQueryable<AuthorBlocking, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AuthorBlocking? authorBlocking = await _authorBlockingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return authorBlocking;
    }

    public async Task<IPaginate<AuthorBlocking>?> GetListAsync(
        Expression<Func<AuthorBlocking, bool>>? predicate = null,
        Func<IQueryable<AuthorBlocking>, IOrderedQueryable<AuthorBlocking>>? orderBy = null,
        Func<IQueryable<AuthorBlocking>, IIncludableQueryable<AuthorBlocking, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AuthorBlocking> authorBlockingList = await _authorBlockingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorBlockingList;
    }

    public async Task<AuthorBlocking> AddAsync(AuthorBlocking authorBlocking)
    {
        AuthorBlocking addedAuthorBlocking = await _authorBlockingRepository.AddAsync(authorBlocking);

        return addedAuthorBlocking;
    }

    public async Task<AuthorBlocking> UpdateAsync(AuthorBlocking authorBlocking)
    {
        AuthorBlocking updatedAuthorBlocking = await _authorBlockingRepository.UpdateAsync(authorBlocking);

        return updatedAuthorBlocking;
    }

    public async Task<AuthorBlocking> DeleteAsync(AuthorBlocking authorBlocking, bool permanent = false)
    {
        AuthorBlocking deletedAuthorBlocking = await _authorBlockingRepository.DeleteAsync(authorBlocking);

        return deletedAuthorBlocking;
    }
}
