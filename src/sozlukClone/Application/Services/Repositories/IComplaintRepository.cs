using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IComplaintRepository : IAsyncRepository<Complaint, Guid>, IRepository<Complaint, Guid>
{
}