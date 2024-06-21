using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRelationsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Authors_FollowerId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Authors_FollowingId",
                table: "Relations");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c5bf34b6-4fcb-4620-ae3d-4c614c01d398"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4112c50b-4038-4ddd-9703-01eebe4a8b80"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("6fda2795-f404-4546-bf1f-e35c2814351b"), 1, new DateTime(2024, 6, 20, 16, 16, 37, 813, DateTimeKind.Utc).AddTicks(2158), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 16, 37, 812, DateTimeKind.Utc).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 16, 37, 814, DateTimeKind.Utc).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 16, 37, 815, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 16, 37, 817, DateTimeKind.Utc).AddTicks(8623));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e9b478b3-46ce-46cc-ba2d-c10a56a2c916"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 193, 15, 72, 130, 105, 204, 99, 200, 227, 48, 231, 150, 234, 11, 73, 78, 16, 70, 147, 38, 226, 211, 43, 160, 232, 146, 157, 212, 224, 121, 185, 201, 0, 20, 49, 140, 70, 91, 47, 37, 113, 107, 179, 16, 61, 180, 25, 85, 198, 52, 216, 186, 4, 137, 37, 160, 40, 181, 235, 207, 228, 221, 209, 197 }, new byte[] { 254, 246, 255, 105, 208, 114, 2, 227, 43, 177, 49, 205, 72, 207, 85, 209, 64, 195, 197, 180, 142, 214, 208, 230, 104, 128, 101, 190, 198, 96, 115, 180, 220, 9, 219, 104, 149, 131, 136, 165, 167, 38, 103, 10, 110, 33, 202, 110, 218, 228, 116, 79, 132, 140, 44, 27, 253, 244, 76, 102, 12, 116, 244, 229, 13, 73, 207, 202, 232, 171, 180, 174, 98, 201, 66, 217, 76, 167, 134, 41, 65, 61, 159, 22, 201, 106, 234, 124, 15, 247, 193, 124, 95, 54, 237, 144, 74, 91, 13, 165, 14, 85, 85, 202, 226, 190, 112, 70, 199, 247, 8, 68, 22, 78, 20, 72, 227, 218, 174, 245, 226, 141, 97, 51, 139, 222, 141, 185 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Authors_FollowerId",
                table: "Relations",
                column: "FollowerId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Authors_FollowingId",
                table: "Relations",
                column: "FollowingId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Authors_FollowerId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Authors_FollowingId",
                table: "Relations");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6fda2795-f404-4546-bf1f-e35c2814351b"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e9b478b3-46ce-46cc-ba2d-c10a56a2c916"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("c5bf34b6-4fcb-4620-ae3d-4c614c01d398"), 1, new DateTime(2024, 6, 20, 16, 9, 35, 86, DateTimeKind.Utc).AddTicks(4547), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 85, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 89, DateTimeKind.Utc).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 90, DateTimeKind.Utc).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 94, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4112c50b-4038-4ddd-9703-01eebe4a8b80"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 30, 182, 38, 118, 8, 177, 237, 199, 125, 78, 157, 137, 127, 134, 42, 51, 48, 16, 174, 32, 110, 139, 16, 37, 200, 185, 48, 48, 60, 116, 94, 157, 164, 246, 54, 17, 118, 132, 192, 98, 21, 231, 78, 59, 143, 212, 70, 10, 176, 77, 202, 14, 143, 173, 112, 21, 154, 171, 209, 125, 153, 79, 116 }, new byte[] { 220, 233, 207, 40, 23, 6, 250, 182, 255, 89, 126, 27, 32, 49, 194, 90, 177, 73, 162, 56, 221, 179, 133, 196, 145, 83, 225, 151, 183, 164, 186, 207, 9, 84, 220, 112, 85, 172, 196, 117, 240, 208, 103, 83, 203, 4, 239, 52, 109, 4, 8, 127, 135, 128, 27, 192, 237, 95, 54, 81, 56, 137, 63, 101, 92, 122, 61, 199, 227, 133, 175, 72, 26, 87, 144, 18, 115, 150, 27, 63, 190, 156, 169, 199, 6, 25, 96, 145, 204, 224, 83, 250, 148, 80, 128, 7, 39, 155, 121, 78, 35, 31, 122, 253, 244, 247, 51, 39, 184, 77, 38, 105, 245, 232, 103, 63, 44, 123, 56, 182, 231, 167, 119, 84, 81, 30, 109, 211 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Authors_FollowerId",
                table: "Relations",
                column: "FollowerId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Authors_FollowingId",
                table: "Relations",
                column: "FollowingId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
