using Application.Features.EntryModOperations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EntryModOperations;

public class EntryModOperationManager : IEntryModOperationService
{
    private readonly IEntryModOperationRepository _entryModOperationRepository;
    private readonly EntryModOperationBusinessRules _entryModOperationBusinessRules;

    public EntryModOperationManager(IEntryModOperationRepository entryModOperationRepository, EntryModOperationBusinessRules entryModOperationBusinessRules)
    {
        _entryModOperationRepository = entryModOperationRepository;
        _entryModOperationBusinessRules = entryModOperationBusinessRules;
    }

    public async Task<EntryModOperation?> GetAsync(
        Expression<Func<EntryModOperation, bool>> predicate,
        Func<IQueryable<EntryModOperation>, IIncludableQueryable<EntryModOperation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EntryModOperation? entryModOperation = await _entryModOperationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return entryModOperation;
    }

    public async Task<IPaginate<EntryModOperation>?> GetListAsync(
        Expression<Func<EntryModOperation, bool>>? predicate = null,
        Func<IQueryable<EntryModOperation>, IOrderedQueryable<EntryModOperation>>? orderBy = null,
        Func<IQueryable<EntryModOperation>, IIncludableQueryable<EntryModOperation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EntryModOperation> entryModOperationList = await _entryModOperationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return entryModOperationList;
    }

    public async Task<EntryModOperation> AddAsync(EntryModOperation entryModOperation)
    {
        EntryModOperation addedEntryModOperation = await _entryModOperationRepository.AddAsync(entryModOperation);

        return addedEntryModOperation;
    }

    public async Task<EntryModOperation> UpdateAsync(EntryModOperation entryModOperation)
    {
        EntryModOperation updatedEntryModOperation = await _entryModOperationRepository.UpdateAsync(entryModOperation);

        return updatedEntryModOperation;
    }

    public async Task<EntryModOperation> DeleteAsync(EntryModOperation entryModOperation, bool permanent = false)
    {
        EntryModOperation deletedEntryModOperation = await _entryModOperationRepository.DeleteAsync(entryModOperation);

        return deletedEntryModOperation;
    }
}
