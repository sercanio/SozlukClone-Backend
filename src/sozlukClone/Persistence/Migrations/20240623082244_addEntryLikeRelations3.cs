using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addEntryLikeRelations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f4c9b83b-a2b2-4a7e-ab0c-dca0a9b94d2f"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("41447456-951c-4147-810d-b747ba1246fd"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("cd5c4c8a-ec8f-4b5b-8aaf-04d67020abe3"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("66161648-65ae-4605-93a1-66595d869809"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("f4c9b83b-a2b2-4a7e-ab0c-dca0a9b94d2f"), 1, new DateTime(2024, 6, 23, 8, 21, 40, 540, DateTimeKind.Utc).AddTicks(3961), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 40, 539, DateTimeKind.Utc).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 40, 543, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 40, 544, DateTimeKind.Utc).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 23, 8, 21, 40, 548, DateTimeKind.Utc).AddTicks(3830));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("41447456-951c-4147-810d-b747ba1246fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 170, 3, 221, 71, 31, 137, 219, 16, 69, 193, 95, 213, 245, 222, 52, 161, 150, 113, 162, 226, 159, 30, 212, 205, 146, 251, 59, 154, 217, 194, 143, 112, 76, 231, 185, 216, 65, 179, 55, 228, 101, 156, 189, 141, 87, 199, 235, 23, 107, 68, 93, 143, 209, 245, 111, 221, 165, 143, 48, 255, 173, 202, 15, 202 }, new byte[] { 49, 120, 47, 244, 20, 194, 184, 169, 158, 251, 155, 156, 187, 168, 18, 161, 140, 55, 38, 80, 103, 36, 216, 18, 65, 36, 43, 185, 217, 165, 98, 204, 93, 124, 119, 22, 93, 175, 32, 180, 54, 122, 169, 162, 236, 73, 13, 130, 89, 133, 141, 51, 196, 244, 246, 115, 48, 236, 152, 166, 189, 97, 10, 1, 221, 149, 81, 180, 43, 234, 30, 106, 172, 116, 138, 96, 31, 56, 175, 165, 155, 117, 239, 176, 246, 201, 96, 154, 248, 93, 248, 98, 222, 17, 153, 116, 115, 125, 52, 7, 79, 77, 212, 201, 221, 247, 94, 79, 6, 172, 177, 242, 51, 250, 43, 125, 222, 7, 214, 62, 145, 136, 143, 72, 143, 254, 18, 121 } });
        }
    }
}
