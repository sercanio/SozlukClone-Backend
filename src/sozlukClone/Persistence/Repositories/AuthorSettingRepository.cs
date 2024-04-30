using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AuthorSettingRepository : EfRepositoryBase<AuthorSetting, uint, BaseDbContext>, IAuthorSettingRepository
{
    public AuthorSettingRepository(BaseDbContext context) : base(context)
    {
    }
}