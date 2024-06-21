using Application.Features.Auth.Constants;
using Application.Features.AuthorGroups.Constants;
using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Features.Authors.Constants;
using Application.Features.AuthorSettings.Constants;
using Application.Features.Badges.Constants;
using Application.Features.Entries.Constants;
using Application.Features.GlobalSettings.Constants;
using Application.Features.LoginAudits.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.Penalties.Constants;
using Application.Features.PenaltyTypes.Constants;
using Application.Features.Titles.Constants;
using Application.Features.TitleSettings.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Relations.Constants;
using Application.Features.Likes.Constants;
using Application.Features.Dislikes.Constants;
using Application.Features.Favorites.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        #region Badges CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BadgesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BadgesOperationClaims.Read },
                new() { Id = ++lastId, Name = BadgesOperationClaims.Write },
                new() { Id = ++lastId, Name = BadgesOperationClaims.Create },
                new() { Id = ++lastId, Name = BadgesOperationClaims.Update },
                new() { Id = ++lastId, Name = BadgesOperationClaims.Delete },
            ]
        );
        #endregion

        #region Entries CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EntriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = EntriesOperationClaims.Read },
                new() { Id = ++lastId, Name = EntriesOperationClaims.Write },
                new() { Id = ++lastId, Name = EntriesOperationClaims.Create },
                new() { Id = ++lastId, Name = EntriesOperationClaims.Update },
                new() { Id = ++lastId, Name = EntriesOperationClaims.Delete },
            ]
        );
        #endregion

        #region Penalties CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Read },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Write },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Create },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Update },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Delete },
            ]
        );
        #endregion

        #region PenaltyTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PenaltyTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PenaltyTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = PenaltyTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = PenaltyTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = PenaltyTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = PenaltyTypesOperationClaims.Delete },
            ]
        );
        #endregion

        #region LoginAudits CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LoginAuditsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LoginAuditsOperationClaims.Read },
                new() { Id = ++lastId, Name = LoginAuditsOperationClaims.Write },
                new() { Id = ++lastId, Name = LoginAuditsOperationClaims.Create },
                new() { Id = ++lastId, Name = LoginAuditsOperationClaims.Update },
                new() { Id = ++lastId, Name = LoginAuditsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Authors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Titles CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TitlesOperationClaims.Admin },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Read },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Write },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Create },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Update },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Delete },
            ]
        );
        #endregion

        #region TitleSettings CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TitleSettingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TitleSettingsOperationClaims.Read },
                new() { Id = ++lastId, Name = TitleSettingsOperationClaims.Write },
                new() { Id = ++lastId, Name = TitleSettingsOperationClaims.Create },
                new() { Id = ++lastId, Name = TitleSettingsOperationClaims.Update },
                new() { Id = ++lastId, Name = TitleSettingsOperationClaims.Delete },
            ]
        );
        #endregion

        #region AuthorSettings CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorSettingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorSettingsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorSettingsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorSettingsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorSettingsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorSettingsOperationClaims.Delete },
            ]
        );
        #endregion

        #region AuthorGroupUserOperationClaims CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorGroupUserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorGroupUserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorGroupUserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorGroupUserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorGroupUserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorGroupUserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        featureOperationClaims.Add(new() { Id = ++lastId, Name = AuthorsOperationClaims.GetByUserName });

        #region AuthorGroups CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorGroupsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorGroupsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorGroupsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorGroupsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorGroupsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorGroupsOperationClaims.Delete },
            ]
        );
        #endregion

        #region GlobalSettings CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GlobalSettingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = GlobalSettingsOperationClaims.Read },
                new() { Id = ++lastId, Name = GlobalSettingsOperationClaims.Write },
                new() { Id = ++lastId, Name = GlobalSettingsOperationClaims.Create },
                new() { Id = ++lastId, Name = GlobalSettingsOperationClaims.Update },
                new() { Id = ++lastId, Name = GlobalSettingsOperationClaims.Delete },
            ]
        );
        #endregion

        featureOperationClaims.Add(new() { Id = ++lastId, Name = TitlesOperationClaims.GetBySlug });

        featureOperationClaims.Add(new() { Id = ++lastId, Name = EntriesOperationClaims.GetListEntryHomePageQuery });

        featureOperationClaims.Add(new() { Id = ++lastId, Name = EntriesOperationClaims.GetListEntryForHomePage });

        featureOperationClaims.Add(new() { Id = ++lastId, Name = TitlesOperationClaims.GetByTitleName });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = EntriesOperationClaims.GetListByAuthorId });
        
        #region Relations CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RelationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RelationsOperationClaims.Read },
                new() { Id = ++lastId, Name = RelationsOperationClaims.Write },
                new() { Id = ++lastId, Name = RelationsOperationClaims.Create },
                new() { Id = ++lastId, Name = RelationsOperationClaims.Update },
                new() { Id = ++lastId, Name = RelationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Likes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LikesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LikesOperationClaims.Read },
                new() { Id = ++lastId, Name = LikesOperationClaims.Write },
                new() { Id = ++lastId, Name = LikesOperationClaims.Create },
                new() { Id = ++lastId, Name = LikesOperationClaims.Update },
                new() { Id = ++lastId, Name = LikesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Dislikes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DislikesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DislikesOperationClaims.Read },
                new() { Id = ++lastId, Name = DislikesOperationClaims.Write },
                new() { Id = ++lastId, Name = DislikesOperationClaims.Create },
                new() { Id = ++lastId, Name = DislikesOperationClaims.Update },
                new() { Id = ++lastId, Name = DislikesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Favorites CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FavoritesOperationClaims.Admin },
                new() { Id = ++lastId, Name = FavoritesOperationClaims.Read },
                new() { Id = ++lastId, Name = FavoritesOperationClaims.Write },
                new() { Id = ++lastId, Name = FavoritesOperationClaims.Create },
                new() { Id = ++lastId, Name = FavoritesOperationClaims.Update },
                new() { Id = ++lastId, Name = FavoritesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = EntriesOperationClaims.GetTopLikedListByAuthorId });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = EntriesOperationClaims.GetMostFavoritedListByAuthorId });
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
