using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILikeRepository : IAsyncRepository<Like, Guid>, IRepository<Like, Guid>
{
}