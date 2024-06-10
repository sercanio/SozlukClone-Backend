using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GlobalSettingRepository : EfRepositoryBase<GlobalSetting, int, BaseDbContext>, IGlobalSettingRepository
{
    private readonly BaseDbContext _context;
    public GlobalSettingRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> GetAsyncCount()
    {
        int count = await _context.GlobalSettings.CountAsync();

        return count;
    }
}