using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleFollowingRepository : IAsyncRepository<TitleFollowing, Guid>, IRepository<TitleFollowing, Guid>
{
}