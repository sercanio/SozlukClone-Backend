using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleModOperationRepository : EfRepositoryBase<TitleModOperation, Guid, BaseDbContext>, ITitleModOperationRepository
{
    public TitleModOperationRepository(BaseDbContext context) : base(context)
    {
    }
}