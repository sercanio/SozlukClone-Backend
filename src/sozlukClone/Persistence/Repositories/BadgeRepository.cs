using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BadgeRepository : EfRepositoryBase<Badge, int, BaseDbContext>, IBadgeRepository
{
    public BadgeRepository(BaseDbContext context) : base(context)
    {
    }
}