using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addEntryLikeRelations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("cd5c4c8a-ec8f-4b5b-8aaf-04d67020abe3"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("66161648-65ae-4605-93a1-66595d869809"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Likes_EntryId",
                table: "Likes",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("3f16401d-615b-4972-9550-06a97406f5af"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3ba8a0d8-6f30-406b-a512-f3c19196bdad"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "EntryId", "AuthorId" });

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("cd5c4c8a-ec8f-4b5b-8aaf-04d67020abe3"), 1, new DateTime(2024, 6, 23, 8, 22, 43, 767, DateTimeKind.Utc).AddTicks(631), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 22, 43, 765, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 22, 43, 771, DateTimeKind.Utc).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 22, 43, 772, DateTimeKind.Utc).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 22, 43, 775, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("66161648-65ae-4605-93a1-66595d869809"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 64, 251, 154, 178, 28, 195, 125, 118, 116, 171, 245, 42, 186, 164, 57, 210, 47, 114, 186, 62, 240, 123, 59, 121, 255, 201, 221, 96, 27, 82, 82, 131, 121, 64, 29, 248, 112, 183, 179, 113, 160, 159, 204, 121, 144, 161, 50, 79, 197, 128, 120, 181, 209, 213, 27, 100, 72, 144, 154, 42, 6, 194, 160, 239 }, new byte[] { 113, 36, 37, 81, 37, 80, 104, 188, 68, 114, 187, 117, 211, 80, 57, 116, 32, 59, 136, 147, 147, 117, 71, 54, 140, 166, 252, 22, 219, 0, 104, 120, 237, 197, 75, 241, 72, 232, 20, 64, 68, 206, 118, 21, 206, 201, 59, 124, 154, 155, 120, 240, 32, 246, 75, 163, 74, 50, 132, 98, 194, 107, 227, 159, 112, 182, 33, 243, 14, 191, 221, 85, 230, 40, 240, 207, 203, 193, 34, 190, 162, 171, 121, 98, 12, 158, 21, 159, 104, 204, 53, 22, 142, 37, 133, 232, 2, 15, 201, 85, 98, 56, 102, 231, 208, 116, 227, 39, 137, 65, 126, 120, 239, 214, 106, 178, 33, 223, 35, 230, 63, 79, 113, 238, 216, 214, 97, 174 } });
        }
    }
}
