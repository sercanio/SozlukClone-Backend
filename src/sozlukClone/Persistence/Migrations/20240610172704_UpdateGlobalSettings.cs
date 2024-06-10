using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGlobalSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d98126b4-c083-47bb-b7ae-58b2736978d9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41ade561-4c4e-4133-a049-bd5f9fa07a1d"));

            migrationBuilder.DropColumn(
                name: "AuthorGroupId",
                table: "AuthorSettings");

            migrationBuilder.InsertData(
                table: "GlobalSettings",
                columns: new[] { "Id", "CreatedDate", "DefaultAuthorGroupId", "DeletedDate", "IsAuthorRegistrationAllowed", "MaxEntryLength", "MaxTitleLength", "SiteDescription", "SiteFavIcon", "SiteLogo", "SiteLogoFooter", "SiteLogoMobile", "SiteName", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 6, 10, 17, 27, 3, 990, DateTimeKind.Utc).AddTicks(1435), 8, null, true, 5000, 50, "Default Description", "default-favicon.ico", "default-logo.png", "default-footer-logo.png", "default-mobile-logo.png", "Default Site", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6920bb2a-44c6-48ee-b532-fd1db7f97375"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 205, 121, 165, 216, 39, 254, 122, 166, 158, 151, 176, 217, 35, 12, 80, 73, 216, 150, 138, 78, 215, 203, 168, 92, 0, 174, 106, 69, 192, 247, 66, 237, 167, 176, 185, 12, 130, 47, 37, 178, 195, 92, 157, 159, 110, 41, 157, 133, 137, 21, 180, 228, 30, 112, 137, 152, 232, 121, 21, 69, 21, 206, 43, 90 }, new byte[] { 146, 32, 153, 100, 74, 245, 18, 10, 116, 253, 210, 250, 109, 201, 202, 7, 8, 88, 89, 146, 245, 212, 220, 222, 48, 182, 52, 195, 168, 212, 69, 194, 175, 205, 157, 124, 188, 27, 81, 19, 1, 12, 201, 96, 134, 205, 62, 236, 175, 158, 7, 109, 224, 215, 42, 168, 70, 105, 37, 212, 12, 57, 64, 198, 222, 22, 190, 78, 192, 124, 46, 118, 58, 109, 237, 204, 87, 255, 186, 24, 217, 106, 182, 40, 40, 119, 56, 14, 118, 4, 204, 213, 111, 10, 227, 97, 230, 196, 215, 248, 124, 120, 114, 168, 135, 91, 244, 118, 121, 59, 90, 233, 237, 8, 183, 159, 110, 55, 48, 63, 135, 187, 51, 53, 137, 252, 143, 178 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("94b3dfcf-1cd2-46c7-a928-85f0c5bc953f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6920bb2a-44c6-48ee-b532-fd1db7f97375") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("94b3dfcf-1cd2-46c7-a928-85f0c5bc953f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6920bb2a-44c6-48ee-b532-fd1db7f97375"));

            migrationBuilder.AddColumn<int>(
                name: "AuthorGroupId",
                table: "AuthorSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AuthorSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuthorGroupId",
                value: 8);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("41ade561-4c4e-4133-a049-bd5f9fa07a1d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 137, 192, 89, 211, 148, 173, 112, 143, 208, 153, 178, 178, 203, 211, 167, 197, 183, 209, 123, 210, 129, 40, 249, 104, 118, 9, 158, 120, 46, 243, 23, 131, 226, 175, 123, 119, 106, 79, 55, 66, 44, 90, 40, 34, 245, 41, 150, 124, 71, 58, 121, 212, 141, 169, 223, 80, 25, 30, 6, 245, 167, 255, 24, 97 }, new byte[] { 168, 63, 4, 155, 25, 220, 243, 247, 35, 74, 199, 127, 185, 245, 35, 54, 117, 239, 149, 82, 76, 177, 115, 141, 15, 68, 236, 74, 16, 35, 1, 166, 158, 247, 207, 205, 120, 102, 147, 130, 53, 5, 59, 184, 94, 214, 126, 138, 40, 127, 178, 175, 82, 50, 216, 107, 10, 69, 74, 8, 64, 30, 72, 21, 8, 144, 173, 159, 59, 228, 185, 47, 238, 25, 236, 91, 63, 66, 215, 63, 223, 203, 182, 32, 223, 197, 138, 184, 96, 58, 232, 44, 104, 181, 249, 121, 154, 6, 81, 95, 90, 9, 195, 130, 101, 123, 212, 224, 253, 8, 32, 29, 116, 16, 158, 204, 68, 13, 85, 53, 7, 97, 174, 222, 221, 226, 219, 120 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d98126b4-c083-47bb-b7ae-58b2736978d9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("41ade561-4c4e-4133-a049-bd5f9fa07a1d") });
        }
    }
}
