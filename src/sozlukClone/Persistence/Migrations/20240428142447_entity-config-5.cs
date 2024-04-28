using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Followings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                columns: new[] { "FollowerId", "FollowedId" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("66cc050d-310f-4c72-b9a6-b39554b9f59f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 7, 217, 65, 199, 119, 44, 169, 65, 78, 192, 14, 146, 192, 4, 78, 112, 232, 38, 14, 203, 174, 74, 38, 220, 103, 108, 252, 33, 203, 78, 164, 76, 113, 47, 66, 123, 101, 252, 201, 155, 143, 83, 209, 19, 53, 128, 85, 114, 17, 163, 58, 169, 15, 81, 9, 43, 56, 66, 215, 134, 121, 34, 174, 71 }, new byte[] { 38, 205, 215, 78, 209, 27, 82, 170, 115, 74, 186, 160, 232, 172, 3, 137, 224, 87, 197, 127, 123, 64, 225, 238, 250, 165, 89, 210, 16, 135, 211, 153, 245, 5, 123, 239, 243, 135, 11, 191, 204, 230, 108, 90, 148, 129, 74, 247, 181, 77, 39, 202, 5, 9, 7, 72, 238, 57, 254, 221, 118, 161, 63, 21, 231, 129, 168, 219, 172, 149, 59, 235, 2, 229, 235, 230, 133, 127, 210, 103, 76, 143, 143, 91, 33, 238, 177, 213, 61, 38, 91, 52, 28, 176, 7, 211, 73, 81, 140, 43, 209, 101, 205, 163, 96, 209, 123, 166, 52, 96, 133, 66, 253, 43, 61, 120, 27, 13, 98, 139, 125, 129, 192, 59, 103, 130, 219, 227 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a90c74b5-f0b9-473f-be78-5c4ce5c25c73"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("66cc050d-310f-4c72-b9a6-b39554b9f59f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a90c74b5-f0b9-473f-be78-5c4ce5c25c73"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66cc050d-310f-4c72-b9a6-b39554b9f59f"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Followings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
