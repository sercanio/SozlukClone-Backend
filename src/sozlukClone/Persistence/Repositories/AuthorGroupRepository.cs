using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorGroupRepository : EfRepositoryBase<AuthorGroup, uint, BaseDbContext>, IAuthorGroupRepository
{
    public AuthorGroupRepository(BaseDbContext context) : base(context)
    {
    }
}