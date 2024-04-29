using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILoginAuditRepository : IAsyncRepository<LoginAudit, Guid>, IRepository<LoginAudit, Guid>
{
}