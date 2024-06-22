using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addAuthorFollowingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings");

            migrationBuilder.DropIndex(
                name: "IX_AuthorFollowings_FollowingId",
                table: "AuthorFollowings");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7537ee04-3936-45ff-a213-b17a7ce28204"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e0ed6216-a35e-43a1-ac24-b69bcd58f86f"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings",
                columns: new[] { "FollowingId", "FollowerId" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("dc0f7de6-fbd8-4c55-8180-d2404e1c4baa"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1245d97b-4290-43d5-b770-2dcc32684ec7"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("7537ee04-3936-45ff-a213-b17a7ce28204"), 1, new DateTime(2024, 6, 22, 18, 34, 11, 8, DateTimeKind.Utc).AddTicks(2634), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 18, 34, 11, 7, DateTimeKind.Utc).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 18, 34, 11, 11, DateTimeKind.Utc).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 18, 34, 11, 12, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 18, 34, 11, 15, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e0ed6216-a35e-43a1-ac24-b69bcd58f86f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 65, 37, 183, 10, 38, 210, 16, 26, 41, 175, 149, 109, 229, 190, 33, 134, 222, 120, 95, 45, 70, 11, 198, 157, 82, 51, 130, 69, 49, 227, 111, 108, 74, 42, 28, 247, 143, 203, 164, 67, 223, 188, 149, 193, 106, 145, 195, 179, 61, 94, 33, 227, 20, 40, 206, 3, 218, 46, 59, 145, 50, 96, 97 }, new byte[] { 106, 231, 60, 1, 69, 185, 37, 78, 195, 59, 11, 76, 225, 55, 88, 154, 186, 48, 187, 153, 43, 127, 157, 119, 19, 239, 138, 47, 130, 141, 78, 140, 48, 214, 185, 73, 105, 22, 93, 190, 93, 232, 143, 199, 216, 227, 137, 216, 115, 64, 56, 204, 165, 42, 98, 74, 75, 225, 100, 78, 98, 186, 214, 45, 246, 217, 74, 242, 244, 239, 3, 69, 126, 79, 226, 47, 151, 99, 142, 139, 129, 233, 88, 239, 52, 229, 57, 72, 77, 76, 127, 81, 216, 91, 47, 237, 230, 125, 27, 94, 45, 97, 137, 192, 193, 228, 21, 33, 202, 30, 188, 189, 53, 128, 24, 91, 108, 156, 44, 120, 111, 252, 142, 63, 123, 201, 247, 144 } });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorFollowings_FollowingId",
                table: "AuthorFollowings",
                column: "FollowingId");
        }
    }
}
