using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Entries;

public class EntryManager : IEntryService
{
    private readonly IEntryRepository _entryRepository;
    private readonly EntryBusinessRules _entryBusinessRules;

    public EntryManager(IEntryRepository entryRepository, EntryBusinessRules entryBusinessRules)
    {
        _entryRepository = entryRepository;
        _entryBusinessRules = entryBusinessRules;
    }

    public async Task<Entry?> GetAsync(
        Expression<Func<Entry, bool>> predicate,
        Func<IQueryable<Entry>, IIncludableQueryable<Entry, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Entry? entry = await _entryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return entry;
    }

    public async Task<IPaginate<Entry>?> GetListAsync(
        Expression<Func<Entry, bool>>? predicate = null,
        Func<IQueryable<Entry>, IOrderedQueryable<Entry>>? orderBy = null,
        Func<IQueryable<Entry>, IIncludableQueryable<Entry, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Entry> entryList = await _entryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return entryList;
    }

    public async Task<Entry> AddAsync(Entry entry)
    {
        Entry addedEntry = await _entryRepository.AddAsync(entry);

        return addedEntry;
    }

    public async Task<Entry> UpdateAsync(Entry entry)
    {
        Entry updatedEntry = await _entryRepository.UpdateAsync(entry);

        return updatedEntry;
    }

    public async Task<Entry> DeleteAsync(Entry entry, bool permanent = false)
    {
        Entry deletedEntry = await _entryRepository.DeleteAsync(entry);

        return deletedEntry;
    }
}
