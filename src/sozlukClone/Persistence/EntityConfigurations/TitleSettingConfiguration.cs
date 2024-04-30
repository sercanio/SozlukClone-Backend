using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TitleSettingConfiguration : IEntityTypeConfiguration<TitleSetting>
{
    public void Configure(EntityTypeBuilder<TitleSetting> builder)
    {
        builder.ToTable("TitleSettings").HasKey(ts => ts.Id);

        builder.Property(ts => ts.Id).HasColumnName("Id").IsRequired();
        builder.Property(ts => ts.MinTitleLength).HasColumnName("MinTitleLength").IsRequired();
        builder.Property(ts => ts.MaxTitleLength).HasColumnName("MaxTitleLength").IsRequired();
        builder.Property(ts => ts.TitleCanHaveLink).HasColumnName("TitleCanHaveLink").IsRequired();
        builder.Property(ts => ts.TitleCanHaveSpecialCharacter).HasColumnName("TitleCanHaveSpecialCharacter").IsRequired();
        builder.Property(ts => ts.TitleCanHavePunctuation).HasColumnName("TitleCanHavePunctuation").IsRequired();
        builder.Property(ts => ts.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ts => ts.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ts => ts.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_seeds);

        builder.HasQueryFilter(ts => !ts.DeletedDate.HasValue);
    }
    private IEnumerable<TitleSetting> _seeds
    {
        get
        {
            return new List<TitleSetting>
            {
                new TitleSetting { Id = 1, MinTitleLength = 1, MaxTitleLength = 50, TitleCanHaveLink = false, TitleCanHaveSpecialCharacter = true, TitleCanHavePunctuation = false},
                };
        }
    }
}