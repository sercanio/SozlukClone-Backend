using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Authors.Constants;
using Application.Features.AuthorGroups.Constants;
using Application.Features.Badges.Constants;
using Application.Features.Entries.Constants;
using Application.Features.Followings.Constants;
using Application.Features.Penalties.Constants;
using Application.Features.Titles.Constants;
using Application.Features.PenaltyTypes.Constants;

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
        
        
        #region Followings CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Read },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Write },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Create },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Update },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Delete },
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
        
        
        #region Followings CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Read },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Write },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Create },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Update },
                new() { Id = ++lastId, Name = FollowingsOperationClaims.Delete },
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
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
