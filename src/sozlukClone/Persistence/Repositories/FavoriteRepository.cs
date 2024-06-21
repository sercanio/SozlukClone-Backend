using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FavoriteRepository : EfRepositoryBase<Favorite, Guid, BaseDbContext>, IFavoriteRepository
{
    public FavoriteRepository(BaseDbContext context) : base(context)
    {
    }
}