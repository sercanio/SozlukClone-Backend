using Application.Services.Likes;

namespace Application.Factories.LikeServiceFactory;

public interface ILikeServiceFactory
{
    ILikeService Create();
}
