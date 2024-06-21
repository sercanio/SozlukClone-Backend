using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRatingOperations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c2384cdd-5c73-4819-be0e-f9e17e8d0333"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("48ecc674-14fe-4124-b757-0c639e7cb8bf"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("256a5b04-8dcf-4db6-84f1-8dd13755e7d7"), 1, new DateTime(2024, 6, 21, 8, 58, 51, 175, DateTimeKind.Utc).AddTicks(6476), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 58, 51, 174, DateTimeKind.Utc).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 58, 51, 177, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 58, 51, 177, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 58, 51, 179, DateTimeKind.Utc).AddTicks(8905));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("beabe818-041e-4675-b072-2fafa84a05ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 203, 71, 250, 162, 206, 126, 49, 132, 36, 11, 113, 142, 234, 79, 73, 191, 75, 91, 47, 182, 251, 255, 80, 169, 34, 151, 12, 28, 185, 163, 211, 21, 27, 228, 89, 175, 251, 114, 255, 200, 20, 192, 27, 13, 190, 33, 38, 21, 227, 203, 17, 1, 124, 203, 217, 93, 12, 61, 31, 235, 1, 159, 247 }, new byte[] { 34, 20, 88, 109, 188, 206, 120, 239, 248, 115, 27, 204, 137, 180, 1, 92, 213, 53, 83, 188, 205, 205, 33, 115, 3, 117, 180, 101, 109, 244, 167, 13, 150, 35, 217, 41, 253, 187, 141, 172, 243, 8, 243, 167, 212, 191, 103, 96, 134, 114, 126, 147, 199, 61, 199, 107, 149, 102, 225, 104, 92, 152, 25, 95, 249, 41, 66, 118, 33, 196, 102, 224, 179, 102, 50, 62, 158, 214, 203, 236, 151, 174, 119, 147, 74, 165, 103, 117, 186, 223, 169, 173, 242, 216, 69, 167, 212, 63, 50, 53, 200, 67, 135, 189, 24, 189, 250, 149, 247, 90, 74, 2, 158, 3, 64, 193, 232, 97, 206, 56, 9, 36, 53, 107, 72, 225, 67, 252 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("256a5b04-8dcf-4db6-84f1-8dd13755e7d7"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("beabe818-041e-4675-b072-2fafa84a05ff"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("c2384cdd-5c73-4819-be0e-f9e17e8d0333"), 1, new DateTime(2024, 6, 21, 8, 53, 24, 78, DateTimeKind.Utc).AddTicks(3207), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 53, 24, 77, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 53, 24, 79, DateTimeKind.Utc).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 53, 24, 79, DateTimeKind.Utc).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 53, 24, 81, DateTimeKind.Utc).AddTicks(8314));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("48ecc674-14fe-4124-b757-0c639e7cb8bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 22, 60, 237, 19, 124, 201, 108, 41, 168, 152, 151, 201, 224, 64, 90, 85, 217, 47, 24, 29, 97, 190, 213, 177, 220, 16, 147, 242, 89, 0, 122, 234, 155, 4, 128, 67, 131, 84, 14, 113, 126, 230, 224, 77, 242, 138, 239, 56, 69, 143, 84, 1, 183, 96, 113, 198, 20, 23, 62, 34, 227, 194, 184, 71 }, new byte[] { 169, 255, 31, 243, 139, 126, 39, 115, 253, 236, 174, 209, 127, 254, 164, 200, 159, 253, 75, 3, 89, 211, 37, 118, 86, 74, 6, 225, 163, 54, 223, 239, 68, 103, 160, 213, 93, 148, 114, 253, 29, 250, 191, 29, 80, 153, 216, 158, 47, 77, 221, 104, 201, 243, 20, 73, 190, 199, 218, 207, 18, 31, 17, 60, 182, 149, 208, 3, 94, 100, 97, 209, 69, 63, 50, 56, 153, 48, 189, 99, 170, 83, 246, 132, 248, 118, 97, 140, 197, 175, 52, 158, 251, 81, 71, 163, 214, 44, 117, 142, 19, 71, 50, 194, 189, 251, 254, 225, 211, 82, 8, 62, 236, 10, 67, 104, 15, 12, 200, 121, 156, 138, 235, 79, 178, 230, 1, 96 } });
        }
    }
}
