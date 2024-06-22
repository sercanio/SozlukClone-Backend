using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorBlockingRepository : EfRepositoryBase<AuthorBlocking, Guid, BaseDbContext>, IAuthorBlockingRepository
{
    public AuthorBlockingRepository(BaseDbContext context) : base(context)
    {
    }
}