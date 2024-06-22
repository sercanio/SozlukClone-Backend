using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorFollowingRepository : IAsyncRepository<AuthorFollowing, Guid>, IRepository<AuthorFollowing, Guid>
{
}