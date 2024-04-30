using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorSetting : Entity<int>
{
    public string ProfilePictureUrl { get; set; }
    public string CoverPictureUrl { get; set; }
    public int AuthorGroupId { get; set; }
    public int ActiveBadgeId { get; set; }

}
