using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCompositeKeyFromAuthorFollowings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9982f081-6d19-4307-9f3a-5b4a343b5680"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f5522a19-18e6-4079-8fdb-db6dc9752363"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("a01da53d-64bf-44a9-92c8-10ec3b9d0819"), 1, new DateTime(2024, 6, 24, 12, 2, 54, 217, DateTimeKind.Utc).AddTicks(6678), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 216, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 223, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 223, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 226, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("91133532-b8b6-4698-b831-a76d148ea354"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 208, 230, 188, 185, 126, 200, 45, 36, 92, 21, 65, 7, 5, 83, 202, 70, 242, 121, 36, 45, 21, 31, 158, 88, 104, 253, 209, 247, 153, 212, 240, 107, 80, 47, 189, 171, 23, 249, 37, 170, 84, 232, 0, 4, 210, 229, 205, 41, 112, 122, 103, 138, 150, 193, 108, 29, 198, 0, 176, 51, 35, 23, 23, 175 }, new byte[] { 126, 78, 214, 191, 159, 199, 7, 190, 174, 63, 46, 255, 209, 77, 216, 211, 87, 154, 236, 49, 118, 224, 81, 26, 186, 170, 162, 129, 2, 201, 182, 111, 254, 49, 233, 1, 183, 178, 223, 19, 172, 57, 251, 133, 66, 244, 186, 150, 233, 57, 235, 203, 28, 200, 92, 59, 46, 112, 171, 28, 114, 36, 187, 243, 27, 99, 194, 202, 201, 54, 51, 116, 244, 244, 39, 21, 230, 104, 179, 70, 208, 183, 1, 184, 94, 201, 17, 36, 108, 254, 101, 126, 50, 133, 73, 57, 82, 21, 17, 55, 233, 62, 114, 156, 248, 9, 42, 152, 230, 245, 67, 90, 12, 32, 64, 16, 80, 175, 162, 200, 116, 233, 84, 160, 188, 232, 46, 179 } });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorFollowings_FollowingId",
                table: "AuthorFollowings",
                column: "FollowingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("a01da53d-64bf-44a9-92c8-10ec3b9d0819"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("91133532-b8b6-4698-b831-a76d148ea354"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollowings",
                table: "AuthorFollowings",
                columns: new[] { "FollowingId", "FollowerId" });

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("9982f081-6d19-4307-9f3a-5b4a343b5680"), 1, new DateTime(2024, 6, 23, 17, 3, 29, 805, DateTimeKind.Utc).AddTicks(6005), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 17, 3, 29, 803, DateTimeKind.Utc).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 17, 3, 29, 811, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 17, 3, 29, 812, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 17, 3, 29, 815, DateTimeKind.Utc).AddTicks(1505));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f5522a19-18e6-4079-8fdb-db6dc9752363"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 87, 174, 178, 33, 171, 148, 54, 100, 83, 52, 17, 110, 189, 133, 160, 86, 227, 104, 20, 153, 55, 97, 95, 197, 138, 70, 206, 35, 199, 49, 13, 16, 140, 78, 225, 191, 244, 232, 69, 160, 165, 41, 195, 125, 231, 218, 210, 37, 88, 114, 232, 83, 38, 193, 56, 27, 166, 199, 192, 200, 228, 168, 168, 139 }, new byte[] { 141, 147, 231, 228, 151, 211, 148, 231, 31, 242, 59, 124, 238, 73, 22, 253, 132, 52, 226, 97, 93, 222, 204, 58, 248, 68, 224, 82, 76, 186, 203, 41, 224, 224, 127, 224, 13, 56, 46, 200, 92, 58, 32, 191, 5, 24, 45, 37, 154, 99, 145, 179, 44, 137, 84, 2, 153, 172, 205, 152, 240, 148, 10, 6, 55, 116, 10, 117, 67, 84, 57, 237, 73, 40, 53, 226, 177, 131, 226, 13, 252, 46, 254, 223, 47, 117, 154, 35, 40, 66, 136, 82, 148, 39, 252, 180, 83, 207, 122, 226, 115, 89, 30, 204, 202, 49, 91, 1, 61, 30, 65, 140, 202, 96, 168, 123, 152, 32, 142, 95, 208, 127, 44, 200, 144, 251, 117, 110 } });
        }
    }
}
