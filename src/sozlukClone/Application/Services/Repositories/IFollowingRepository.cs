using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFollowingRepository : IAsyncRepository<Following, Guid>, IRepository<Following, Guid>
{
}