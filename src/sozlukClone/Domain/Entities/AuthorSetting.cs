using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorSetting : Entity<uint>
{
    public string ProfilePictureUrl { get; set; }
    public string CoverPictureUrl { get; set; }
    public uint AuthorGroupId { get; set; }
    public uint ActiveBadgeId { get; set; }

}
