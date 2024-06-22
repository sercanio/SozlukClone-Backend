using Application.Features.TitleModOperations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleModOperations;

public class TitleModOperationManager : ITitleModOperationService
{
    private readonly ITitleModOperationRepository _titleModOperationRepository;
    private readonly TitleModOperationBusinessRules _titleModOperationBusinessRules;

    public TitleModOperationManager(ITitleModOperationRepository titleModOperationRepository, TitleModOperationBusinessRules titleModOperationBusinessRules)
    {
        _titleModOperationRepository = titleModOperationRepository;
        _titleModOperationBusinessRules = titleModOperationBusinessRules;
    }

    public async Task<TitleModOperation?> GetAsync(
        Expression<Func<TitleModOperation, bool>> predicate,
        Func<IQueryable<TitleModOperation>, IIncludableQueryable<TitleModOperation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TitleModOperation? titleModOperation = await _titleModOperationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return titleModOperation;
    }

    public async Task<IPaginate<TitleModOperation>?> GetListAsync(
        Expression<Func<TitleModOperation, bool>>? predicate = null,
        Func<IQueryable<TitleModOperation>, IOrderedQueryable<TitleModOperation>>? orderBy = null,
        Func<IQueryable<TitleModOperation>, IIncludableQueryable<TitleModOperation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TitleModOperation> titleModOperationList = await _titleModOperationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return titleModOperationList;
    }

    public async Task<TitleModOperation> AddAsync(TitleModOperation titleModOperation)
    {
        TitleModOperation addedTitleModOperation = await _titleModOperationRepository.AddAsync(titleModOperation);

        return addedTitleModOperation;
    }

    public async Task<TitleModOperation> UpdateAsync(TitleModOperation titleModOperation)
    {
        TitleModOperation updatedTitleModOperation = await _titleModOperationRepository.UpdateAsync(titleModOperation);

        return updatedTitleModOperation;
    }

    public async Task<TitleModOperation> DeleteAsync(TitleModOperation titleModOperation, bool permanent = false)
    {
        TitleModOperation deletedTitleModOperation = await _titleModOperationRepository.DeleteAsync(titleModOperation);

        return deletedTitleModOperation;
    }
}
