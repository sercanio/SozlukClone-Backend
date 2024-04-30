using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorSettingRepository : IAsyncRepository<AuthorSetting, int>, IRepository<AuthorSetting, int>
{
}