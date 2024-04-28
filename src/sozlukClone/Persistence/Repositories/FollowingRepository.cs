using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FollowingRepository : EfRepositoryBase<Following, Guid, BaseDbContext>, IFollowingRepository
{
    public FollowingRepository(BaseDbContext context) : base(context)
    {
    }
}