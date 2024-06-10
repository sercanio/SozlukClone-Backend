using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthorGroups_Name",
                table: "AuthorGroups");

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7545f840-c50a-451d-b803-97f720d26678"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b7951240-6356-46f1-b7a5-d1034cd9dae0"));

            migrationBuilder.CreateTable(
                name: "GlobalSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SiteName = table.Column<string>(type: "text", nullable: true),
                    SiteDescription = table.Column<string>(type: "text", nullable: true),
                    SiteFavIcon = table.Column<string>(type: "text", nullable: true),
                    SiteLogo = table.Column<string>(type: "text", nullable: true),
                    SiteLogoFooter = table.Column<string>(type: "text", nullable: true),
                    SiteLogoMobile = table.Column<string>(type: "text", nullable: true),
                    MaxTitleLength = table.Column<int>(type: "integer", nullable: true),
                    DefaultAuthorGroupId = table.Column<int>(type: "integer", nullable: false),
                    DefaultAuthorGroup = table.Column<string>(type: "text", nullable: true),
                    IsAuthorRegistrationAllowed = table.Column<bool>(type: "boolean", nullable: true),
                    MaxEntryLength = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GlobalSettings",
                columns: new[] { "Id", "CreatedDate", "DefaultAuthorGroup", "DefaultAuthorGroupId", "DeletedDate", "IsAuthorRegistrationAllowed", "MaxEntryLength", "MaxTitleLength", "SiteDescription", "SiteFavIcon", "SiteLogo", "SiteLogoFooter", "SiteLogoMobile", "SiteName", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, true, 5000, 200, "?çsel Bilgi Kayna??", "favicon.ico", "logo.png", "footer-logo.png", "mobile-logo.png", "SozlukClone", null });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Badges.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Badges.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Badges.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Badges.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Badges.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Badges.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Entries.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Entries.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Entries.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Entries.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Entries.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Entries.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Penalties.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Penalties.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Penalties.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "Penalties.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Penalties.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Penalties.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "PenaltyTypes.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "PenaltyTypes.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "PenaltyTypes.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "PenaltyTypes.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "PenaltyTypes.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "PenaltyTypes.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "LoginAudits.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "LoginAudits.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "LoginAudits.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "LoginAudits.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "LoginAudits.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "LoginAudits.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Authors.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Authors.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Authors.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Authors.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Authors.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Authors.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Titles.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Titles.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "Name",
                value: "Titles.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "Titles.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "Titles.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 65,
                column: "Name",
                value: "Titles.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 66,
                column: "Name",
                value: "TitleSettings.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 67,
                column: "Name",
                value: "TitleSettings.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "Name",
                value: "TitleSettings.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 69,
                column: "Name",
                value: "TitleSettings.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "TitleSettings.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 71,
                column: "Name",
                value: "TitleSettings.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72,
                column: "Name",
                value: "AuthorSettings.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "AuthorSettings.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "AuthorSettings.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "AuthorSettings.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "AuthorSettings.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "AuthorSettings.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "Authors.GetByUserName");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "AuthorGroups.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "AuthorGroups.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "AuthorGroups.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "AuthorGroups.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "AuthorGroups.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "AuthorGroups.Delete");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Admin", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Read", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Write", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Create", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Update", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9462522d-ac8e-48e9-806e-6aba60df7e1b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 252, 230, 188, 240, 129, 45, 157, 146, 143, 248, 24, 140, 193, 115, 186, 172, 212, 203, 15, 198, 159, 210, 164, 124, 208, 186, 70, 97, 235, 95, 73, 112, 254, 19, 15, 240, 0, 42, 52, 195, 102, 65, 47, 29, 84, 2, 45, 72, 182, 154, 94, 250, 214, 178, 239, 141, 200, 80, 46, 44, 1, 14, 6, 235 }, new byte[] { 178, 235, 155, 224, 222, 231, 121, 251, 54, 64, 133, 12, 91, 145, 238, 97, 209, 41, 4, 235, 194, 2, 171, 217, 53, 69, 35, 228, 174, 96, 223, 240, 68, 102, 220, 109, 77, 163, 101, 63, 109, 36, 189, 221, 102, 156, 244, 134, 147, 216, 166, 171, 232, 53, 131, 223, 51, 94, 113, 214, 158, 76, 140, 195, 113, 91, 14, 97, 51, 165, 116, 181, 211, 31, 135, 228, 176, 164, 120, 75, 34, 73, 65, 77, 98, 125, 25, 31, 45, 3, 13, 146, 97, 254, 198, 82, 35, 53, 71, 131, 97, 190, 125, 117, 87, 221, 138, 151, 76, 129, 62, 0, 37, 38, 40, 5, 112, 153, 157, 199, 223, 241, 182, 218, 189, 109, 165, 15 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("5905d39d-b690-4666-b9f4-c345f23aefdb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("9462522d-ac8e-48e9-806e-6aba60df7e1b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalSettings");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5905d39d-b690-4666-b9f4-c345f23aefdb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9462522d-ac8e-48e9-806e-6aba60df7e1b"));

            migrationBuilder.InsertData(
                table: "AuthorGroups",
                columns: new[] { "Id", "Color", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "#FF0000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Developer", "Developer", null },
                    { 2, "#00FF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SuperAdmin", "SuperAdmin", null },
                    { 3, "#0000FF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", "Admin", null },
                    { 4, "#FFFF00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SuperModerator", "SuperModerator", null },
                    { 5, "#FF00FF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Moderator", "Moderator", null },
                    { 6, "#00FFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Editor", "Editor", null },
                    { 7, "#C0C0C0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Author", "Author", null },
                    { 8, "#808080", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Guest", "Noob", null },
                    { 9, "#800000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suspended", "Suspended", null },
                    { 10, "#008000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Banned", "Banned", null }
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "AuthorGroups.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "AuthorGroups.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "AuthorGroups.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "AuthorGroups.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "AuthorGroups.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "AuthorGroups.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Badges.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Badges.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Badges.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Badges.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Badges.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Badges.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Entries.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Entries.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Entries.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "Entries.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Entries.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Entries.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "Penalties.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Penalties.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "Penalties.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Penalties.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Penalties.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Penalties.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "PenaltyTypes.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "PenaltyTypes.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "PenaltyTypes.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "PenaltyTypes.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "PenaltyTypes.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "PenaltyTypes.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "LoginAudits.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "LoginAudits.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "LoginAudits.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "LoginAudits.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "LoginAudits.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "LoginAudits.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Authors.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Authors.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "Name",
                value: "Authors.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "Authors.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "Authors.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 65,
                column: "Name",
                value: "Authors.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 66,
                column: "Name",
                value: "Titles.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 67,
                column: "Name",
                value: "Titles.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "Name",
                value: "Titles.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 69,
                column: "Name",
                value: "Titles.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "Titles.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 71,
                column: "Name",
                value: "Titles.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72,
                column: "Name",
                value: "TitleSettings.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "TitleSettings.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "TitleSettings.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "TitleSettings.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "TitleSettings.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "TitleSettings.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "AuthorSettings.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "AuthorSettings.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "AuthorSettings.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "AuthorSettings.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "AuthorSettings.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "AuthorSettings.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "AuthorGroupUserOperationClaims.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Authors.GetByUserName");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("b7951240-6356-46f1-b7a5-d1034cd9dae0"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 159, 155, 205, 40, 19, 74, 159, 181, 160, 202, 243, 154, 219, 139, 174, 254, 72, 157, 51, 214, 222, 88, 82, 11, 62, 253, 168, 167, 70, 98, 191, 105, 78, 77, 115, 85, 167, 116, 234, 54, 50, 202, 13, 39, 126, 48, 40, 209, 208, 26, 52, 30, 48, 217, 173, 48, 97, 36, 61, 155, 134, 119, 237, 217 }, new byte[] { 119, 213, 15, 251, 193, 151, 131, 81, 103, 252, 104, 109, 231, 26, 156, 111, 110, 140, 146, 151, 59, 13, 7, 168, 253, 21, 105, 240, 139, 249, 130, 31, 110, 110, 88, 135, 212, 108, 5, 34, 14, 56, 159, 38, 136, 242, 62, 27, 167, 230, 217, 80, 238, 35, 252, 89, 121, 209, 191, 254, 122, 96, 70, 144, 129, 124, 31, 15, 68, 17, 240, 24, 197, 137, 84, 44, 150, 50, 18, 4, 107, 53, 74, 33, 149, 113, 68, 63, 136, 179, 218, 24, 67, 97, 10, 246, 197, 65, 86, 51, 232, 223, 248, 58, 245, 149, 1, 217, 141, 211, 69, 25, 192, 169, 39, 60, 36, 204, 214, 96, 207, 167, 236, 42, 21, 241, 237, 16 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7545f840-c50a-451d-b803-97f720d26678"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b7951240-6356-46f1-b7a5-d1034cd9dae0") });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGroups_Name",
                table: "AuthorGroups",
                column: "Name",
                unique: true);
        }
    }
}
