using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuthorSettingsSeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("580231c3-fceb-467b-8b91-de6f43b1f281"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a7c130a7-b269-4bf9-ae3d-c5170bc31f32"));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IconUrl",
                value: "default-icon.png");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3df24ce1-64e8-4427-8eb4-5cc169aae311"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 198, 188, 33, 238, 81, 17, 37, 32, 43, 255, 230, 191, 110, 160, 152, 32, 236, 143, 107, 247, 181, 119, 15, 199, 133, 92, 126, 184, 101, 196, 164, 155, 59, 141, 30, 174, 170, 149, 143, 77, 71, 51, 155, 19, 181, 29, 66, 27, 101, 81, 32, 186, 107, 70, 99, 94, 2, 70, 156, 74, 215, 225, 74, 140 }, new byte[] { 163, 184, 41, 188, 69, 65, 40, 36, 65, 27, 57, 126, 123, 66, 86, 84, 233, 132, 145, 86, 214, 38, 252, 40, 215, 236, 5, 135, 71, 42, 205, 142, 55, 110, 7, 158, 245, 128, 138, 218, 198, 201, 162, 150, 1, 148, 4, 85, 3, 75, 91, 21, 144, 59, 87, 95, 78, 101, 210, 187, 187, 192, 191, 194, 116, 251, 211, 129, 72, 81, 9, 11, 85, 232, 201, 210, 161, 60, 100, 217, 26, 133, 210, 88, 3, 12, 185, 207, 93, 75, 11, 63, 59, 235, 125, 140, 113, 255, 90, 155, 29, 115, 241, 114, 187, 147, 95, 34, 122, 15, 19, 49, 233, 249, 17, 69, 212, 57, 204, 66, 156, 3, 251, 90, 136, 20, 219, 254 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c86d9a58-e392-4768-9324-ec3b403c4321"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3df24ce1-64e8-4427-8eb4-5cc169aae311") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c86d9a58-e392-4768-9324-ec3b403c4321"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3df24ce1-64e8-4427-8eb4-5cc169aae311"));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IconUrl",
                value: "https://localhost:5001/images/badges/rookie.png");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("a7c130a7-b269-4bf9-ae3d-c5170bc31f32"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 149, 222, 247, 130, 83, 114, 173, 57, 48, 218, 12, 22, 167, 5, 170, 160, 59, 60, 56, 214, 176, 236, 109, 232, 209, 226, 78, 57, 167, 160, 198, 31, 80, 50, 19, 173, 111, 234, 229, 228, 233, 67, 143, 248, 208, 25, 208, 213, 158, 51, 227, 222, 151, 164, 36, 92, 168, 98, 1, 46, 245, 240, 204, 223 }, new byte[] { 156, 20, 112, 36, 147, 65, 83, 29, 184, 18, 198, 238, 165, 192, 192, 68, 172, 139, 150, 234, 34, 147, 151, 138, 108, 54, 178, 78, 105, 32, 56, 76, 36, 48, 135, 95, 149, 55, 126, 32, 250, 20, 130, 31, 98, 12, 90, 147, 187, 140, 153, 131, 152, 7, 246, 242, 101, 180, 118, 136, 30, 31, 116, 246, 55, 23, 162, 140, 199, 19, 164, 120, 217, 63, 72, 228, 111, 242, 59, 205, 28, 169, 113, 196, 64, 135, 220, 82, 124, 31, 113, 242, 46, 52, 38, 74, 19, 1, 117, 143, 251, 127, 20, 18, 19, 208, 204, 2, 252, 252, 155, 24, 4, 106, 74, 88, 162, 57, 148, 103, 198, 224, 4, 217, 200, 19, 28, 192 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("580231c3-fceb-467b-8b91-de6f43b1f281"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a7c130a7-b269-4bf9-ae3d-c5170bc31f32") });
        }
    }
}
