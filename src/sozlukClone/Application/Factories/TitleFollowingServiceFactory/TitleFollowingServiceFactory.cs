using Application.Services.TitleFollowings;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories.TitleFollowingServiceFactory;

public class TitleFollowingServiceFactory : ITitleFollowingServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TitleFollowingServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITitleFollowingService Create()
    {
        return _serviceProvider.GetRequiredService<ITitleFollowingService>();
    }
}