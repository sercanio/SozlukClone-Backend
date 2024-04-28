using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("243d8c43-76a8-4f25-a882-c5ce778f5ef4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("156b9e2b-7b86-4d22-85bd-90db518b0922"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("25670ac5-af69-45e7-a343-6890dfe353ee"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 163, 198, 22, 71, 82, 151, 87, 72, 86, 138, 26, 235, 5, 246, 30, 58, 24, 142, 51, 252, 2, 98, 151, 110, 81, 139, 8, 203, 117, 255, 38, 254, 158, 144, 231, 170, 22, 77, 228, 155, 233, 217, 165, 179, 196, 182, 43, 176, 149, 80, 114, 167, 48, 4, 0, 56, 43, 150, 133, 78, 133, 204, 174, 155 }, new byte[] { 203, 57, 214, 234, 135, 170, 242, 62, 231, 235, 211, 178, 121, 254, 123, 157, 220, 178, 134, 117, 165, 171, 140, 44, 74, 171, 38, 82, 192, 37, 64, 181, 210, 3, 229, 237, 152, 17, 116, 34, 212, 103, 148, 60, 151, 29, 241, 157, 115, 244, 126, 141, 139, 195, 47, 233, 116, 14, 107, 87, 17, 187, 253, 25, 81, 137, 97, 194, 197, 64, 104, 121, 115, 133, 238, 251, 228, 165, 121, 143, 49, 162, 15, 233, 11, 55, 147, 96, 174, 236, 11, 63, 13, 119, 189, 216, 118, 84, 49, 95, 155, 219, 197, 177, 185, 182, 178, 197, 27, 84, 63, 2, 125, 37, 79, 37, 51, 52, 0, 180, 83, 97, 18, 21, 142, 233, 169, 221 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8275b863-611c-4246-86c8-cf37593e834d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("25670ac5-af69-45e7-a343-6890dfe353ee") });

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowerId",
                table: "Followings",
                column: "FollowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_FollowerId",
                table: "Followings");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8275b863-611c-4246-86c8-cf37593e834d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25670ac5-af69-45e7-a343-6890dfe353ee"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                columns: new[] { "FollowerId", "FollowedId" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("156b9e2b-7b86-4d22-85bd-90db518b0922"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 125, 0, 243, 175, 207, 240, 191, 184, 135, 106, 53, 55, 78, 37, 154, 165, 210, 9, 168, 160, 206, 154, 249, 178, 146, 239, 194, 31, 212, 130, 59, 191, 228, 60, 240, 40, 17, 251, 192, 108, 98, 246, 196, 124, 94, 213, 67, 72, 136, 168, 123, 138, 180, 63, 122, 124, 188, 218, 148, 253, 238, 181, 217, 22 }, new byte[] { 86, 49, 111, 63, 254, 45, 238, 122, 54, 68, 83, 92, 87, 143, 212, 104, 128, 98, 80, 154, 94, 85, 11, 195, 234, 219, 235, 154, 242, 28, 51, 255, 102, 241, 236, 207, 173, 82, 23, 93, 88, 28, 121, 201, 98, 165, 133, 238, 147, 228, 87, 241, 44, 42, 164, 240, 115, 6, 191, 5, 131, 40, 156, 213, 144, 171, 245, 81, 85, 202, 170, 172, 179, 85, 13, 87, 233, 122, 4, 4, 90, 194, 210, 188, 12, 23, 222, 89, 139, 127, 167, 141, 84, 35, 12, 119, 120, 235, 156, 3, 104, 202, 213, 184, 254, 192, 148, 13, 228, 202, 191, 135, 51, 84, 57, 133, 213, 9, 45, 203, 5, 236, 16, 75, 252, 44, 176, 173 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("243d8c43-76a8-4f25-a882-c5ce778f5ef4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("156b9e2b-7b86-4d22-85bd-90db518b0922") });
        }
    }
}
