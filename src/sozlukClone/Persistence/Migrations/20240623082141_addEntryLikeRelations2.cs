using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addEntryLikeRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9f2e6f67-8a32-4636-b869-513a7bfbbbb5"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("74c2829a-7ce3-401e-aff4-edb0368c9747"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
