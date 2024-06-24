using Application.Factories.LikeServiceFactory;
using Application.Services.Dislikes;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories.DislikeServiceFactory;

public class DislikeServiceFactory : IDislikeServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DislikeServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IDislikeService Create()
    {
        return _serviceProvider.GetRequiredService<IDislikeService>();
    }
}