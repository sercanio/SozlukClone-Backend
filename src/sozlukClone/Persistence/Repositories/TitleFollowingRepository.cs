using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleFollowingRepository : EfRepositoryBase<TitleFollowing, Guid, BaseDbContext>, ITitleFollowingRepository
{
    public TitleFollowingRepository(BaseDbContext context) : base(context)
    {
    }
}