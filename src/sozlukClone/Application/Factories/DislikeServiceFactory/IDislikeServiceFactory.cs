using Application.Services.Dislikes;

namespace Application.Factories.LikeServiceFactory;

public interface IDislikeServiceFactory
{
    IDislikeService Create();
}
