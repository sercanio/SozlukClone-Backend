using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("13834bc8-bf70-401a-bfe7-e16769d67f71"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("130133a8-a367-4ca2-b424-81433129c06c"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("5034847f-e6c2-4dba-9f2d-28c230e0c19d"), 1, new DateTime(2024, 6, 16, 13, 46, 42, 551, DateTimeKind.Utc).AddTicks(1414), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 16, 13, 46, 42, 550, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 16, 13, 46, 42, 552, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 16, 13, 46, 42, 552, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name", "slug" },
                values: new object[] { new DateTime(2024, 6, 16, 13, 46, 42, 555, DateTimeKind.Utc).AddTicks(1534), "sozlukclone projesi", "sozluk-clone-1" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6a46e21e-8e58-42e7-9289-6ddc402ad571"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 30, 252, 212, 48, 173, 63, 32, 46, 251, 75, 77, 172, 113, 52, 235, 98, 15, 138, 238, 188, 107, 134, 207, 104, 148, 235, 74, 151, 28, 110, 214, 111, 31, 199, 152, 76, 218, 6, 202, 67, 160, 45, 29, 233, 11, 32, 77, 24, 250, 51, 114, 81, 182, 179, 233, 252, 157, 122, 175, 125, 45, 242, 149, 154 }, new byte[] { 176, 68, 43, 93, 81, 93, 227, 30, 62, 110, 161, 236, 146, 192, 76, 192, 146, 197, 1, 129, 133, 79, 243, 44, 74, 130, 212, 185, 239, 187, 198, 215, 16, 43, 48, 220, 138, 6, 5, 197, 25, 241, 206, 196, 95, 187, 47, 150, 253, 13, 174, 124, 189, 213, 206, 164, 124, 106, 251, 32, 214, 225, 37, 121, 195, 0, 138, 113, 127, 138, 49, 64, 100, 68, 27, 77, 50, 223, 62, 245, 226, 45, 35, 115, 53, 180, 69, 36, 117, 99, 25, 177, 124, 63, 168, 178, 179, 195, 35, 211, 126, 72, 159, 236, 84, 114, 152, 173, 243, 35, 72, 84, 80, 223, 180, 110, 29, 176, 59, 37, 146, 133, 139, 227, 172, 209, 125, 63 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5034847f-e6c2-4dba-9f2d-28c230e0c19d"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6a46e21e-8e58-42e7-9289-6ddc402ad571"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("13834bc8-bf70-401a-bfe7-e16769d67f71"), 1, new DateTime(2024, 6, 13, 21, 29, 46, 810, DateTimeKind.Utc).AddTicks(9545), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 13, 21, 29, 46, 809, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 13, 21, 29, 46, 812, DateTimeKind.Utc).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 13, 21, 29, 46, 813, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name", "slug" },
                values: new object[] { new DateTime(2024, 6, 13, 21, 29, 46, 816, DateTimeKind.Utc).AddTicks(3804), "SozlukClone", "sozlukclone-1" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("130133a8-a367-4ca2-b424-81433129c06c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 180, 39, 13, 193, 183, 121, 119, 21, 227, 192, 230, 60, 206, 59, 96, 119, 180, 229, 24, 79, 136, 29, 244, 68, 7, 87, 35, 106, 255, 143, 35, 237, 184, 159, 66, 27, 0, 166, 55, 103, 101, 94, 130, 166, 198, 221, 212, 222, 163, 134, 109, 103, 44, 0, 59, 193, 86, 244, 23, 49, 204, 75, 2, 186 }, new byte[] { 30, 122, 30, 251, 20, 77, 135, 251, 94, 207, 162, 158, 237, 156, 178, 250, 46, 182, 10, 230, 102, 120, 39, 44, 178, 41, 89, 33, 169, 25, 177, 181, 170, 170, 205, 108, 201, 150, 68, 196, 104, 62, 209, 133, 66, 153, 42, 190, 26, 86, 121, 136, 178, 50, 69, 157, 7, 125, 99, 6, 199, 183, 184, 178, 17, 83, 62, 59, 21, 89, 12, 8, 37, 92, 64, 80, 151, 148, 138, 14, 59, 201, 246, 66, 212, 18, 77, 56, 109, 216, 75, 236, 28, 53, 115, 201, 39, 252, 56, 25, 80, 234, 25, 61, 234, 166, 28, 214, 150, 62, 235, 164, 97, 99, 234, 144, 114, 10, 215, 235, 42, 53, 16, 192, 231, 120, 100, 110 } });
        }
    }
}
