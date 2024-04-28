using Application.Features.AuthorGroups.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorGroups;

public class AuthorGroupManager : IAuthorGroupService
{
    private readonly IAuthorGroupRepository _authorGroupRepository;
    private readonly AuthorGroupBusinessRules _authorGroupBusinessRules;

    public AuthorGroupManager(IAuthorGroupRepository authorGroupRepository, AuthorGroupBusinessRules authorGroupBusinessRules)
    {
        _authorGroupRepository = authorGroupRepository;
        _authorGroupBusinessRules = authorGroupBusinessRules;
    }

    public async Task<AuthorGroup?> GetAsync(
        Expression<Func<AuthorGroup, bool>> predicate,
        Func<IQueryable<AuthorGroup>, IIncludableQueryable<AuthorGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AuthorGroup? authorGroup = await _authorGroupRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return authorGroup;
    }

    public async Task<IPaginate<AuthorGroup>?> GetListAsync(
        Expression<Func<AuthorGroup, bool>>? predicate = null,
        Func<IQueryable<AuthorGroup>, IOrderedQueryable<AuthorGroup>>? orderBy = null,
        Func<IQueryable<AuthorGroup>, IIncludableQueryable<AuthorGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AuthorGroup> authorGroupList = await _authorGroupRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorGroupList;
    }

    public async Task<AuthorGroup> AddAsync(AuthorGroup authorGroup)
    {
        AuthorGroup addedAuthorGroup = await _authorGroupRepository.AddAsync(authorGroup);

        return addedAuthorGroup;
    }

    public async Task<AuthorGroup> UpdateAsync(AuthorGroup authorGroup)
    {
        AuthorGroup updatedAuthorGroup = await _authorGroupRepository.UpdateAsync(authorGroup);

        return updatedAuthorGroup;
    }

    public async Task<AuthorGroup> DeleteAsync(AuthorGroup authorGroup, bool permanent = false)
    {
        AuthorGroup deletedAuthorGroup = await _authorGroupRepository.DeleteAsync(authorGroup);

        return deletedAuthorGroup;
    }
}
