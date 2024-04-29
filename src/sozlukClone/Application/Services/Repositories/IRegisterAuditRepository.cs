using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRegisterAuditRepository : IAsyncRepository<RegisterAudit, Guid>, IRepository<RegisterAudit, Guid>
{
}