using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EntryRepository : EfRepositoryBase<Entry, uint, BaseDbContext>, IEntryRepository
{
    public EntryRepository(BaseDbContext context) : base(context)
    {
    }
}