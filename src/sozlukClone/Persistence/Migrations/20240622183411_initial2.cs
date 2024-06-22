using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8acfb010-be5a-46d6-a750-87d4cb7765af"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("77209001-5320-4f5b-ad19-9ab6ce7270ba"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7537ee04-3936-45ff-a213-b17a7ce28204"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e0ed6216-a35e-43a1-ac24-b69bcd58f86f"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("8acfb010-be5a-46d6-a750-87d4cb7765af"), 1, new DateTime(2024, 6, 22, 17, 49, 17, 247, DateTimeKind.Utc).AddTicks(3118), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 49, 17, 246, DateTimeKind.Utc).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 49, 17, 251, DateTimeKind.Utc).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 49, 17, 251, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 49, 17, 254, DateTimeKind.Utc).AddTicks(7078));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("77209001-5320-4f5b-ad19-9ab6ce7270ba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 35, 170, 45, 108, 71, 6, 221, 239, 7, 125, 101, 228, 210, 96, 130, 95, 192, 88, 136, 4, 209, 58, 170, 243, 121, 27, 149, 63, 133, 189, 212, 54, 136, 157, 142, 152, 225, 155, 175, 93, 253, 166, 235, 158, 194, 230, 126, 5, 146, 251, 147, 112, 91, 191, 164, 191, 133, 22, 31, 19, 10, 46, 18, 150 }, new byte[] { 95, 137, 77, 194, 44, 45, 33, 180, 2, 213, 250, 239, 157, 192, 140, 71, 18, 132, 189, 71, 236, 151, 145, 142, 232, 159, 8, 133, 212, 26, 3, 30, 62, 112, 79, 72, 145, 160, 105, 183, 239, 157, 244, 191, 178, 24, 162, 171, 37, 156, 133, 89, 9, 179, 136, 207, 88, 129, 137, 69, 19, 39, 218, 169, 34, 230, 174, 251, 26, 227, 248, 4, 162, 65, 58, 114, 97, 11, 176, 20, 127, 101, 80, 136, 244, 73, 245, 128, 227, 77, 6, 75, 103, 3, 15, 137, 188, 41, 9, 245, 4, 249, 164, 169, 157, 110, 22, 173, 209, 157, 163, 7, 2, 116, 55, 163, 150, 214, 139, 231, 59, 171, 43, 169, 9, 79, 34, 246 } });
        }
    }
}
