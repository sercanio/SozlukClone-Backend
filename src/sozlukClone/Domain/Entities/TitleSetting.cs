using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class TitleSetting : Entity<int>
{
    public byte MinTitleLength { get; set; }
    public byte MaxTitleLength { get; set; }
    public bool TitleCanHaveLink { get; set; }
    public bool TitleCanHaveSpecialCharacter { get; set; }
    public bool TitleCanHavePunctuation { get; set; }
}
