using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorGroupUserOperationClaimRepository : EfRepositoryBase<AuthorGroupUserOperationClaim, Guid, BaseDbContext>, IAuthorGroupUserOperationClaimRepository
{
    public AuthorGroupUserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}