using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleBlockingRepository : IAsyncRepository<TitleBlocking, Guid>, IRepository<TitleBlocking, Guid>
{
}