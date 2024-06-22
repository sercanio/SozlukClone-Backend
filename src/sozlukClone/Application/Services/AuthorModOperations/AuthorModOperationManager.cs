using Application.Features.AuthorModOperations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorModOperations;

public class AuthorModOperationManager : IAuthorModOperationService
{
    private readonly IAuthorModOperationRepository _authorModOperationRepository;
    private readonly AuthorModOperationBusinessRules _authorModOperationBusinessRules;

    public AuthorModOperationManager(IAuthorModOperationRepository authorModOperationRepository, AuthorModOperationBusinessRules authorModOperationBusinessRules)
    {
        _authorModOperationRepository = authorModOperationRepository;
        _authorModOperationBusinessRules = authorModOperationBusinessRules;
    }

    public async Task<AuthorModOperation?> GetAsync(
        Expression<Func<AuthorModOperation, bool>> predicate,
        Func<IQueryable<AuthorModOperation>, IIncludableQueryable<AuthorModOperation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AuthorModOperation? authorModOperation = await _authorModOperationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return authorModOperation;
    }

    public async Task<IPaginate<AuthorModOperation>?> GetListAsync(
        Expression<Func<AuthorModOperation, bool>>? predicate = null,
        Func<IQueryable<AuthorModOperation>, IOrderedQueryable<AuthorModOperation>>? orderBy = null,
        Func<IQueryable<AuthorModOperation>, IIncludableQueryable<AuthorModOperation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AuthorModOperation> authorModOperationList = await _authorModOperationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorModOperationList;
    }

    public async Task<AuthorModOperation> AddAsync(AuthorModOperation authorModOperation)
    {
        AuthorModOperation addedAuthorModOperation = await _authorModOperationRepository.AddAsync(authorModOperation);

        return addedAuthorModOperation;
    }

    public async Task<AuthorModOperation> UpdateAsync(AuthorModOperation authorModOperation)
    {
        AuthorModOperation updatedAuthorModOperation = await _authorModOperationRepository.UpdateAsync(authorModOperation);

        return updatedAuthorModOperation;
    }

    public async Task<AuthorModOperation> DeleteAsync(AuthorModOperation authorModOperation, bool permanent = false)
    {
        AuthorModOperation deletedAuthorModOperation = await _authorModOperationRepository.DeleteAsync(authorModOperation);

        return deletedAuthorModOperation;
    }
}
