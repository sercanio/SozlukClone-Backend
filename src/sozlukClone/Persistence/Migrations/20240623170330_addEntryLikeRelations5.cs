using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addEntryLikeRelations5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleFollowings",
                table: "TitleFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleBlockings",
                table: "TitleBlockings");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3f16401d-615b-4972-9550-06a97406f5af"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3ba8a0d8-6f30-406b-a512-f3c19196bdad"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleFollowings",
                table: "TitleFollowings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleBlockings",
                table: "TitleBlockings",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_TitleFollowings_TitleId",
                table: "TitleFollowings",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleBlockings_TitleId",
                table: "TitleBlockings",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleFollowings",
                table: "TitleFollowings");

            migrationBuilder.DropIndex(
                name: "IX_TitleFollowings_TitleId",
                table: "TitleFollowings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleBlockings",
                table: "TitleBlockings");

            migrationBuilder.DropIndex(
                name: "IX_TitleBlockings_TitleId",
                table: "TitleBlockings");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9982f081-6d19-4307-9f3a-5b4a343b5680"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f5522a19-18e6-4079-8fdb-db6dc9752363"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleFollowings",
                table: "TitleFollowings",
                columns: new[] { "TitleId", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleBlockings",
                table: "TitleBlockings",
                columns: new[] { "TitleId", "AuthorId" });

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("3f16401d-615b-4972-9550-06a97406f5af"), 1, new DateTime(2024, 6, 23, 13, 30, 27, 382, DateTimeKind.Utc).AddTicks(3667), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 13, 30, 27, 381, DateTimeKind.Utc).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 13, 30, 27, 386, DateTimeKind.Utc).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 13, 30, 27, 387, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 13, 30, 27, 390, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3ba8a0d8-6f30-406b-a512-f3c19196bdad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 226, 83, 15, 66, 202, 143, 44, 2, 34, 40, 3, 54, 35, 99, 206, 209, 193, 67, 138, 126, 249, 101, 149, 56, 120, 235, 29, 206, 155, 249, 91, 234, 234, 0, 48, 0, 177, 79, 114, 71, 226, 12, 49, 87, 208, 45, 103, 18, 200, 105, 221, 140, 224, 107, 123, 230, 149, 168, 124, 102, 226, 56, 156, 232 }, new byte[] { 147, 11, 8, 144, 108, 71, 93, 69, 143, 253, 134, 9, 118, 38, 93, 107, 30, 110, 69, 117, 131, 78, 59, 57, 145, 250, 177, 82, 164, 240, 146, 98, 36, 118, 47, 253, 38, 187, 246, 144, 232, 222, 221, 154, 140, 33, 236, 105, 29, 9, 233, 141, 244, 82, 42, 238, 146, 31, 252, 200, 201, 165, 213, 224, 208, 195, 163, 90, 208, 6, 93, 12, 9, 239, 104, 66, 123, 10, 206, 171, 131, 231, 6, 251, 6, 34, 229, 254, 205, 227, 65, 75, 92, 192, 189, 114, 143, 51, 236, 166, 158, 81, 174, 72, 80, 52, 123, 44, 117, 75, 10, 208, 146, 26, 200, 4, 176, 226, 66, 255, 188, 243, 3, 118, 64, 253, 225, 64 } });
        }
    }
}
