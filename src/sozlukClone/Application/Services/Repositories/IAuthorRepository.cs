using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorRepository : IAsyncRepository<Author, uint>, IRepository<Author, uint>
{
}