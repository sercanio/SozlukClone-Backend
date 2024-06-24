using Application.Services.Favorites;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories.FavoriteServiceFactory;

public class FavoriteServiceFactory : IFavoriteServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FavoriteServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IFavoriteService Create()
    {
        return _serviceProvider.GetRequiredService<IFavoriteService>();
    }
}