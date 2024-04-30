using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuthorSettingsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3f7fdb3c-ffae-4fd0-ac57-8fb9793bcf7c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7ee377f5-4f7c-4096-bbb1-ceaf60a72778"));

            migrationBuilder.InsertData(
                table: "AuthorSettings",
                columns: new[] { "Id", "ActiveBadgeId", "AuthorGroupId", "CoverPictureUrl", "CreatedDate", "DeletedDate", "ProfilePictureUrl", "UpdatedDate" },
                values: new object[] { 1L, 1L, 8L, "default-cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "default-profile.png", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("a7c130a7-b269-4bf9-ae3d-c5170bc31f32"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 149, 222, 247, 130, 83, 114, 173, 57, 48, 218, 12, 22, 167, 5, 170, 160, 59, 60, 56, 214, 176, 236, 109, 232, 209, 226, 78, 57, 167, 160, 198, 31, 80, 50, 19, 173, 111, 234, 229, 228, 233, 67, 143, 248, 208, 25, 208, 213, 158, 51, 227, 222, 151, 164, 36, 92, 168, 98, 1, 46, 245, 240, 204, 223 }, new byte[] { 156, 20, 112, 36, 147, 65, 83, 29, 184, 18, 198, 238, 165, 192, 192, 68, 172, 139, 150, 234, 34, 147, 151, 138, 108, 54, 178, 78, 105, 32, 56, 76, 36, 48, 135, 95, 149, 55, 126, 32, 250, 20, 130, 31, 98, 12, 90, 147, 187, 140, 153, 131, 152, 7, 246, 242, 101, 180, 118, 136, 30, 31, 116, 246, 55, 23, 162, 140, 199, 19, 164, 120, 217, 63, 72, 228, 111, 242, 59, 205, 28, 169, 113, 196, 64, 135, 220, 82, 124, 31, 113, 242, 46, 52, 38, 74, 19, 1, 117, 143, 251, 127, 20, 18, 19, 208, 204, 2, 252, 252, 155, 24, 4, 106, 74, 88, 162, 57, 148, 103, 198, 224, 4, 217, 200, 19, 28, 192 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("580231c3-fceb-467b-8b91-de6f43b1f281"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a7c130a7-b269-4bf9-ae3d-c5170bc31f32") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorSettings",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("580231c3-fceb-467b-8b91-de6f43b1f281"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a7c130a7-b269-4bf9-ae3d-c5170bc31f32"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("7ee377f5-4f7c-4096-bbb1-ceaf60a72778"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 89, 161, 17, 178, 105, 78, 119, 237, 168, 108, 190, 121, 195, 231, 113, 36, 233, 102, 255, 160, 125, 131, 246, 9, 15, 252, 235, 174, 7, 97, 54, 192, 146, 187, 87, 125, 182, 126, 166, 181, 176, 229, 200, 96, 254, 109, 165, 147, 218, 23, 94, 187, 206, 215, 117, 61, 209, 154, 145, 230, 112, 227, 197, 219 }, new byte[] { 17, 120, 217, 55, 47, 148, 178, 83, 171, 128, 118, 168, 226, 12, 81, 50, 188, 10, 160, 253, 8, 162, 205, 184, 27, 228, 67, 198, 133, 13, 101, 39, 164, 124, 107, 167, 82, 73, 73, 214, 184, 127, 66, 11, 74, 210, 229, 239, 111, 252, 132, 100, 89, 136, 78, 170, 26, 42, 59, 17, 152, 120, 141, 78, 127, 209, 91, 171, 53, 88, 139, 220, 129, 253, 215, 191, 245, 64, 71, 95, 6, 63, 25, 20, 142, 81, 246, 32, 39, 10, 57, 195, 116, 27, 30, 24, 105, 25, 30, 3, 56, 224, 101, 49, 182, 159, 196, 153, 49, 104, 214, 47, 0, 207, 223, 88, 79, 207, 191, 155, 104, 221, 247, 214, 123, 224, 73, 88 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3f7fdb3c-ffae-4fd0-ac57-8fb9793bcf7c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7ee377f5-4f7c-4096-bbb1-ceaf60a72778") });
        }
    }
}
