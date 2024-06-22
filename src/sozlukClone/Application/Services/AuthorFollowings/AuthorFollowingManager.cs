using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorFollowings;

public class AuthorFollowingManager : IAuthorFollowingService
{
    private readonly IAuthorFollowingRepository _authorFollowingRepository;
    private readonly AuthorFollowingBusinessRules _authorFollowingBusinessRules;

    public AuthorFollowingManager(IAuthorFollowingRepository authorFollowingRepository, AuthorFollowingBusinessRules authorFollowingBusinessRules)
    {
        _authorFollowingRepository = authorFollowingRepository;
        _authorFollowingBusinessRules = authorFollowingBusinessRules;
    }

    public async Task<AuthorFollowing?> GetAsync(
        Expression<Func<AuthorFollowing, bool>> predicate,
        Func<IQueryable<AuthorFollowing>, IIncludableQueryable<AuthorFollowing, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AuthorFollowing? authorFollowing = await _authorFollowingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return authorFollowing;
    }

    public async Task<IPaginate<AuthorFollowing>?> GetListAsync(
        Expression<Func<AuthorFollowing, bool>>? predicate = null,
        Func<IQueryable<AuthorFollowing>, IOrderedQueryable<AuthorFollowing>>? orderBy = null,
        Func<IQueryable<AuthorFollowing>, IIncludableQueryable<AuthorFollowing, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AuthorFollowing> authorFollowingList = await _authorFollowingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorFollowingList;
    }

    public async Task<AuthorFollowing> AddAsync(AuthorFollowing authorFollowing)
    {
        AuthorFollowing addedAuthorFollowing = await _authorFollowingRepository.AddAsync(authorFollowing);

        return addedAuthorFollowing;
    }

    public async Task<AuthorFollowing> UpdateAsync(AuthorFollowing authorFollowing)
    {
        AuthorFollowing updatedAuthorFollowing = await _authorFollowingRepository.UpdateAsync(authorFollowing);

        return updatedAuthorFollowing;
    }

    public async Task<AuthorFollowing> DeleteAsync(AuthorFollowing authorFollowing, bool permanent = false)
    {
        AuthorFollowing deletedAuthorFollowing = await _authorFollowingRepository.DeleteAsync(authorFollowing);

        return deletedAuthorFollowing;
    }
}
