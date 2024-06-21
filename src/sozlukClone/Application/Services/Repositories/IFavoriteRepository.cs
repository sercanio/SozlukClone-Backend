using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFavoriteRepository : IAsyncRepository<Favorite, Guid>, IRepository<Favorite, Guid>
{
}