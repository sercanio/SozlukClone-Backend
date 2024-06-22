using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EntryModOperationRepository : EfRepositoryBase<EntryModOperation, Guid, BaseDbContext>, IEntryModOperationRepository
{
    public EntryModOperationRepository(BaseDbContext context) : base(context)
    {
    }
}