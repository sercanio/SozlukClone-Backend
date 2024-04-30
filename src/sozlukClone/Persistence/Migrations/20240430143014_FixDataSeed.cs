using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("92cb515c-65ae-4965-b3bf-ba8e5c8af7f4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d33c656-d9ea-4f13-94b2-b5755f42f230"));

            migrationBuilder.InsertData(
                table: "AuthorGroups",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Developer", "Developer", null },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SuperAdmin", "SuperAdmin", null },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", "Admin", null },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SuperModerator", "SuperModerator", null },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Moderator", "Moderator", null },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Editor", "Editor", null },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Author", "Author", null },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Guest", "Noob", null },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suspended", "Suspended", null },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Banned", "Banned", null }
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IconUrl", "Name", "UpdatedDate" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Default", "https://localhost:5001/images/badges/rookie.png", "Default", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6cb77ce1-90bc-41b9-8f9d-fc8b19a14aea"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 199, 81, 152, 254, 193, 176, 7, 205, 9, 143, 108, 180, 10, 253, 19, 74, 233, 124, 179, 65, 255, 218, 87, 101, 4, 23, 72, 189, 170, 128, 240, 224, 221, 59, 34, 204, 202, 64, 87, 161, 145, 187, 71, 179, 89, 39, 72, 137, 138, 193, 136, 36, 31, 99, 206, 143, 4, 59, 35, 244, 107, 130, 199, 200 }, new byte[] { 244, 129, 255, 131, 42, 192, 17, 69, 89, 250, 189, 3, 81, 215, 99, 102, 242, 52, 183, 46, 125, 204, 12, 10, 137, 74, 148, 216, 32, 82, 41, 148, 22, 206, 137, 156, 156, 38, 62, 105, 117, 96, 8, 159, 122, 80, 93, 153, 62, 4, 43, 7, 176, 176, 25, 27, 120, 177, 10, 22, 63, 151, 175, 95, 216, 51, 117, 211, 142, 137, 77, 81, 69, 67, 217, 113, 170, 215, 199, 213, 65, 9, 85, 13, 149, 170, 61, 133, 146, 133, 221, 146, 70, 162, 170, 184, 14, 238, 13, 216, 170, 216, 248, 107, 200, 230, 119, 211, 143, 82, 192, 42, 225, 99, 27, 62, 242, 91, 31, 76, 34, 124, 145, 6, 70, 244, 225, 179 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7f209f83-9959-43f0-bd1a-31d01a14cfad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6cb77ce1-90bc-41b9-8f9d-fc8b19a14aea") });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_Name",
                table: "Badges",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGroups_Name",
                table: "AuthorGroups",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Badges_Name",
                table: "Badges");

            migrationBuilder.DropIndex(
                name: "IX_AuthorGroups_Name",
                table: "AuthorGroups");

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7f209f83-9959-43f0-bd1a-31d01a14cfad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6cb77ce1-90bc-41b9-8f9d-fc8b19a14aea"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("8d33c656-d9ea-4f13-94b2-b5755f42f230"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 191, 122, 104, 233, 232, 67, 92, 57, 169, 225, 123, 110, 109, 225, 105, 202, 108, 68, 63, 205, 231, 47, 252, 249, 64, 68, 131, 233, 160, 73, 79, 88, 54, 119, 29, 245, 137, 32, 225, 248, 37, 185, 179, 230, 234, 248, 90, 68, 96, 43, 67, 2, 252, 87, 46, 199, 253, 32, 165, 89, 176, 61, 63, 173 }, new byte[] { 121, 62, 84, 170, 208, 105, 84, 55, 248, 5, 41, 214, 136, 104, 172, 126, 8, 44, 17, 95, 191, 198, 80, 105, 235, 140, 132, 248, 63, 5, 209, 67, 7, 90, 218, 178, 12, 145, 237, 26, 73, 103, 237, 124, 92, 9, 249, 18, 218, 24, 166, 219, 96, 234, 186, 76, 43, 190, 12, 111, 153, 75, 253, 39, 9, 140, 149, 209, 108, 31, 217, 168, 88, 213, 73, 93, 121, 118, 171, 78, 98, 128, 74, 162, 121, 16, 164, 152, 165, 13, 240, 157, 49, 143, 64, 183, 204, 172, 158, 215, 235, 123, 59, 11, 197, 56, 102, 21, 94, 117, 43, 216, 200, 73, 205, 17, 129, 76, 151, 46, 134, 236, 152, 109, 249, 11, 74, 75 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("92cb515c-65ae-4965-b3bf-ba8e5c8af7f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8d33c656-d9ea-4f13-94b2-b5755f42f230") });
        }
    }
}
