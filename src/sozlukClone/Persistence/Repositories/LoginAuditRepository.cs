using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LoginAuditRepository : EfRepositoryBase<LoginAudit, Guid, BaseDbContext>, ILoginAuditRepository
{
    public LoginAuditRepository(BaseDbContext context) : base(context)
    {
    }
}