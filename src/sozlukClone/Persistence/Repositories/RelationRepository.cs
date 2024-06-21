using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RelationRepository : EfRepositoryBase<Relation, Guid, BaseDbContext>, IRelationRepository
{
    public RelationRepository(BaseDbContext context) : base(context)
    {
    }
}