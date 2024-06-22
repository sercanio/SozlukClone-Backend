using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorModOperationRepository : EfRepositoryBase<AuthorModOperation, Guid, BaseDbContext>, IAuthorModOperationRepository
{
    public AuthorModOperationRepository(BaseDbContext context) : base(context)
    {
    }
}