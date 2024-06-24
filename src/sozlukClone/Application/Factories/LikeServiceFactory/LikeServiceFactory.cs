using Application.Services.Likes;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories.LikeServiceFactory;

public class LikeServiceFactory : ILikeServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public LikeServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ILikeService Create()
    {
        return _serviceProvider.GetRequiredService<ILikeService>();
    }
}