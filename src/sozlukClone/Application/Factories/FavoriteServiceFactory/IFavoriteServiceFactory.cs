using Application.Services.Favorites;

namespace Application.Factories.FavoriteServiceFactory;

public interface IFavoriteServiceFactory
{
    IFavoriteService Create();
}
