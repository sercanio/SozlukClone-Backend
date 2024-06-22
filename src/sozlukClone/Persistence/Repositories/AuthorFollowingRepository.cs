using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorFollowingRepository : EfRepositoryBase<AuthorFollowing, Guid, BaseDbContext>, IAuthorFollowingRepository
{
    public AuthorFollowingRepository(BaseDbContext context) : base(context)
    {
    }
}