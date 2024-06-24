using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateKarmaMultipliersInGlobalSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5d4b11ea-af81-44de-a357-4260f9f6a02e"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d04b3b92-aab1-4a1c-9b8f-87ac9e4e00f2"));

            migrationBuilder.AddColumn<decimal>(
                name: "BaseKarma",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlockedTitlesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlockersMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlockingsMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplaintApprovedCountMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplaintCountMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplaintPendingCountMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplaintRejectedCountMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplaintedEntriesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplaintedTitlesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EntryMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FollowedTitlesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FollowerMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FollowingMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GivenDislikesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GivenFavoritesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GivenLikesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivedDislikesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivedFavoritesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivedLikesMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TitleMultiplier",
                table: "GlobalSettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("b27d7a60-2b86-40c1-9551-e690fd24638d"), 1, new DateTime(2024, 6, 24, 17, 23, 11, 204, DateTimeKind.Utc).AddTicks(2004), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 23, 11, 203, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 23, 11, 209, DateTimeKind.Utc).AddTicks(2825));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BaseKarma", "BlockedTitlesMultiplier", "BlockersMultiplier", "BlockingsMultiplier", "ComplaintApprovedCountMultiplier", "ComplaintCountMultiplier", "ComplaintPendingCountMultiplier", "ComplaintRejectedCountMultiplier", "ComplaintedEntriesMultiplier", "ComplaintedTitlesMultiplier", "CreatedDate", "EntryMultiplier", "FollowedTitlesMultiplier", "FollowerMultiplier", "FollowingMultiplier", "GivenDislikesMultiplier", "GivenFavoritesMultiplier", "GivenLikesMultiplier", "ReceivedDislikesMultiplier", "ReceivedFavoritesMultiplier", "ReceivedLikesMultiplier", "TitleMultiplier" },
                values: new object[] { 0m, -0.001m, -1.0m, -0.1m, 0.001m, 0.0005m, 0.0m, -0.001m, -0.0001m, -0.0001m, new DateTime(2024, 6, 24, 17, 23, 11, 210, DateTimeKind.Utc).AddTicks(6025), 0.1m, 0.001m, 1.0m, 0.01m, -0.001m, 0.002m, 0.001m, -0.005m, 0.25m, 0.01m, 0.2m });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 23, 11, 214, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9083be49-35ed-4c4f-8b54-aa9deadf2ce2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 79, 130, 165, 41, 85, 212, 118, 224, 176, 73, 12, 55, 51, 228, 61, 49, 142, 60, 6, 206, 191, 128, 88, 188, 70, 67, 234, 166, 22, 11, 28, 89, 100, 98, 185, 14, 37, 248, 28, 84, 47, 135, 154, 204, 23, 92, 75, 220, 206, 232, 189, 127, 6, 22, 76, 57, 186, 184, 223, 98, 39, 12, 139, 51 }, new byte[] { 44, 16, 99, 128, 73, 152, 116, 140, 10, 178, 72, 248, 178, 9, 92, 143, 65, 251, 193, 70, 30, 81, 15, 72, 28, 242, 227, 242, 242, 209, 204, 102, 142, 13, 142, 56, 189, 15, 219, 217, 112, 41, 176, 39, 215, 6, 115, 67, 89, 153, 5, 147, 34, 48, 87, 56, 242, 96, 183, 20, 109, 63, 0, 68, 4, 70, 98, 106, 38, 94, 74, 206, 235, 107, 18, 99, 217, 195, 101, 159, 74, 98, 35, 14, 231, 72, 12, 25, 34, 18, 150, 179, 19, 195, 95, 51, 241, 111, 96, 163, 221, 233, 24, 128, 170, 145, 115, 62, 72, 246, 75, 250, 135, 120, 183, 67, 189, 187, 204, 21, 185, 225, 147, 164, 252, 155, 210, 112 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b27d7a60-2b86-40c1-9551-e690fd24638d"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9083be49-35ed-4c4f-8b54-aa9deadf2ce2"));

            migrationBuilder.DropColumn(
                name: "BaseKarma",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "BlockedTitlesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "BlockersMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "BlockingsMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ComplaintApprovedCountMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ComplaintCountMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ComplaintPendingCountMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ComplaintRejectedCountMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ComplaintedEntriesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ComplaintedTitlesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "EntryMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "FollowedTitlesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "FollowerMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "FollowingMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "GivenDislikesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "GivenFavoritesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "GivenLikesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ReceivedDislikesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ReceivedFavoritesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "ReceivedLikesMultiplier",
                table: "GlobalSettings");

            migrationBuilder.DropColumn(
                name: "TitleMultiplier",
                table: "GlobalSettings");

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("5d4b11ea-af81-44de-a357-4260f9f6a02e"), 1, new DateTime(2024, 6, 24, 17, 6, 32, 949, DateTimeKind.Utc).AddTicks(4851), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 948, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 954, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 955, DateTimeKind.Utc).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 959, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d04b3b92-aab1-4a1c-9b8f-87ac9e4e00f2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 70, 231, 234, 60, 142, 181, 182, 250, 156, 96, 115, 174, 101, 168, 232, 73, 11, 75, 139, 219, 152, 34, 85, 138, 85, 249, 56, 198, 176, 10, 42, 89, 60, 158, 179, 20, 251, 11, 151, 204, 70, 252, 112, 84, 135, 199, 137, 95, 39, 231, 254, 169, 8, 248, 202, 176, 207, 157, 237, 111, 145, 199, 97 }, new byte[] { 159, 192, 78, 160, 108, 19, 134, 40, 52, 117, 24, 63, 47, 78, 70, 27, 199, 23, 134, 24, 31, 59, 252, 210, 160, 0, 198, 45, 41, 189, 196, 203, 62, 66, 5, 117, 66, 1, 196, 74, 107, 137, 251, 197, 45, 49, 254, 179, 58, 46, 194, 183, 125, 210, 77, 102, 13, 21, 202, 80, 65, 48, 189, 17, 142, 225, 105, 238, 74, 222, 206, 118, 59, 187, 95, 233, 152, 97, 17, 238, 22, 78, 250, 41, 6, 93, 27, 217, 102, 150, 245, 5, 221, 25, 228, 173, 139, 136, 193, 123, 246, 226, 31, 233, 191, 31, 71, 221, 89, 34, 44, 246, 106, 23, 7, 172, 231, 171, 148, 79, 50, 133, 7, 35, 152, 99, 22, 180 } });
        }
    }
}
