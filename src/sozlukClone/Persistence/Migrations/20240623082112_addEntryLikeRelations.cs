using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addEntryLikeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_EntryId",
                table: "Likes");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("dc0f7de6-fbd8-4c55-8180-d2404e1c4baa"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1245d97b-4290-43d5-b770-2dcc32684ec7"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "EntryId", "AuthorId" });

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("9f2e6f67-8a32-4636-b869-513a7bfbbbb5"), 1, new DateTime(2024, 6, 23, 8, 21, 12, 57, DateTimeKind.Utc).AddTicks(6762), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 12, 56, DateTimeKind.Utc).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 12, 61, DateTimeKind.Utc).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 12, 62, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 12, 66, DateTimeKind.Utc).AddTicks(477));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("74c2829a-7ce3-401e-aff4-edb0368c9747"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 26, 177, 163, 63, 169, 64, 234, 111, 141, 219, 89, 163, 88, 188, 50, 170, 40, 107, 34, 225, 186, 144, 111, 146, 35, 12, 121, 10, 7, 124, 146, 139, 67, 154, 226, 231, 248, 31, 99, 125, 232, 127, 32, 29, 164, 34, 153, 163, 212, 24, 236, 19, 21, 114, 29, 132, 247, 130, 30, 215, 85, 19, 119, 25 }, new byte[] { 72, 127, 158, 54, 221, 206, 186, 176, 234, 199, 67, 168, 80, 97, 15, 58, 104, 21, 49, 177, 130, 129, 112, 237, 218, 44, 136, 56, 107, 7, 187, 21, 10, 130, 6, 169, 8, 25, 156, 192, 203, 36, 214, 61, 61, 238, 15, 181, 74, 57, 135, 108, 50, 142, 228, 20, 67, 170, 15, 139, 143, 133, 139, 87, 173, 72, 4, 105, 90, 208, 136, 74, 200, 94, 66, 231, 209, 106, 218, 154, 91, 96, 92, 226, 60, 249, 203, 159, 251, 170, 77, 176, 236, 179, 239, 180, 177, 11, 146, 26, 15, 178, 113, 248, 75, 239, 112, 147, 115, 217, 108, 30, 45, 237, 195, 221, 75, 83, 90, 25, 139, 27, 82, 186, 81, 244, 3, 129 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9f2e6f67-8a32-4636-b869-513a7bfbbbb5"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("74c2829a-7ce3-401e-aff4-edb0368c9747"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("dc0f7de6-fbd8-4c55-8180-d2404e1c4baa"), 1, new DateTime(2024, 6, 22, 21, 53, 38, 317, DateTimeKind.Utc).AddTicks(9008), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 21, 53, 38, 316, DateTimeKind.Utc).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 21, 53, 38, 321, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 21, 53, 38, 322, DateTimeKind.Utc).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 21, 53, 38, 325, DateTimeKind.Utc).AddTicks(9747));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1245d97b-4290-43d5-b770-2dcc32684ec7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 173, 119, 180, 87, 187, 191, 13, 119, 17, 217, 150, 123, 78, 108, 105, 100, 63, 81, 119, 209, 99, 139, 208, 174, 18, 3, 93, 157, 111, 154, 98, 5, 245, 46, 24, 119, 228, 63, 127, 57, 15, 69, 77, 230, 3, 211, 144, 98, 133, 197, 76, 236, 167, 241, 35, 79, 122, 111, 220, 6, 171, 77, 121 }, new byte[] { 64, 53, 131, 126, 45, 50, 130, 167, 156, 79, 250, 214, 17, 79, 51, 91, 15, 39, 248, 155, 218, 159, 243, 216, 177, 96, 162, 67, 130, 239, 108, 146, 150, 111, 128, 196, 111, 196, 140, 35, 254, 53, 125, 48, 49, 17, 92, 2, 16, 104, 24, 139, 120, 39, 131, 191, 200, 19, 117, 223, 253, 202, 206, 153, 116, 72, 230, 160, 100, 0, 217, 53, 117, 15, 216, 201, 242, 201, 19, 233, 134, 13, 3, 68, 123, 61, 164, 187, 241, 127, 127, 150, 142, 166, 208, 114, 233, 202, 18, 10, 203, 59, 32, 2, 118, 124, 72, 205, 210, 159, 53, 109, 46, 21, 158, 219, 77, 211, 112, 167, 171, 51, 104, 93, 195, 140, 55, 131 } });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_EntryId",
                table: "Likes",
                column: "EntryId");
        }
    }
}
