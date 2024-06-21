using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRatingOperations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bbed1591-80dd-4285-83c0-74af61de517c"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e04dfc0d-f127-4be2-beac-b41543ea4304"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("bbed1591-80dd-4285-83c0-74af61de517c"), 1, new DateTime(2024, 6, 21, 8, 51, 30, 798, DateTimeKind.Utc).AddTicks(8308), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 51, 30, 797, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 51, 30, 801, DateTimeKind.Utc).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 51, 30, 802, DateTimeKind.Utc).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 21, 8, 51, 30, 806, DateTimeKind.Utc).AddTicks(734));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e04dfc0d-f127-4be2-beac-b41543ea4304"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 95, 79, 84, 204, 162, 101, 34, 34, 141, 29, 134, 132, 6, 35, 76, 5, 155, 130, 121, 166, 67, 174, 16, 198, 109, 103, 199, 149, 6, 161, 69, 94, 155, 221, 160, 16, 7, 211, 125, 180, 57, 172, 5, 48, 110, 104, 13, 254, 73, 189, 31, 141, 100, 27, 57, 129, 246, 82, 57, 55, 19, 233, 147, 250 }, new byte[] { 221, 57, 168, 212, 162, 165, 205, 51, 154, 223, 164, 116, 167, 43, 4, 8, 204, 95, 28, 185, 44, 50, 161, 72, 111, 177, 9, 16, 96, 152, 152, 230, 63, 250, 173, 154, 152, 118, 225, 17, 112, 18, 20, 184, 68, 29, 34, 29, 185, 142, 110, 37, 38, 165, 200, 197, 179, 226, 164, 79, 33, 46, 178, 24, 83, 217, 254, 149, 190, 138, 202, 140, 254, 112, 209, 41, 154, 9, 186, 33, 242, 147, 177, 139, 230, 206, 53, 141, 175, 84, 151, 52, 39, 34, 91, 1, 126, 10, 4, 208, 158, 214, 20, 7, 19, 103, 36, 143, 171, 80, 242, 58, 249, 216, 253, 102, 152, 157, 209, 80, 135, 159, 139, 89, 62, 208, 165, 157 } });
        }
    }
}
