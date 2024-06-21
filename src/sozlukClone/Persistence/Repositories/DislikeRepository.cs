using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DislikeRepository : EfRepositoryBase<Dislike, Guid, BaseDbContext>, IDislikeRepository
{
    public DislikeRepository(BaseDbContext context) : base(context)
    {
    }
}