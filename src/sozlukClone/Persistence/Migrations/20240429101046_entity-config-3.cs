using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1df15b96-2190-440a-8d86-f84c922dce55"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("23a1e832-287f-436b-8c2d-453d22471c0b"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("feed66ed-c41d-49a0-bf93-185119c553e2"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 237, 2, 30, 149, 30, 178, 35, 68, 111, 188, 214, 161, 60, 171, 33, 18, 2, 166, 40, 72, 179, 66, 102, 92, 97, 66, 194, 144, 139, 118, 240, 172, 60, 55, 85, 6, 181, 104, 101, 129, 118, 114, 48, 232, 86, 184, 35, 46, 157, 104, 131, 21, 86, 234, 132, 100, 193, 146, 117, 1, 169, 227, 203, 190 }, new byte[] { 16, 119, 79, 109, 29, 193, 206, 233, 186, 188, 146, 214, 118, 25, 216, 47, 56, 209, 228, 44, 49, 194, 196, 112, 156, 129, 186, 130, 218, 243, 249, 94, 87, 8, 58, 187, 36, 149, 219, 193, 104, 17, 162, 140, 39, 90, 210, 225, 51, 53, 13, 90, 200, 14, 73, 139, 65, 91, 238, 253, 222, 227, 209, 227, 0, 107, 4, 51, 231, 178, 126, 157, 75, 120, 37, 125, 17, 35, 13, 155, 233, 150, 83, 13, 39, 14, 148, 29, 96, 250, 206, 207, 254, 213, 14, 121, 204, 209, 156, 39, 87, 166, 222, 164, 21, 117, 151, 107, 220, 183, 233, 162, 70, 101, 22, 147, 90, 17, 232, 253, 253, 45, 151, 20, 68, 98, 176, 79 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8bba1afb-8446-41fd-a900-bc858c3d93d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("feed66ed-c41d-49a0-bf93-185119c553e2") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8bba1afb-8446-41fd-a900-bc858c3d93d7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("feed66ed-c41d-49a0-bf93-185119c553e2"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("23a1e832-287f-436b-8c2d-453d22471c0b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 58, 210, 112, 100, 145, 226, 245, 209, 161, 227, 89, 91, 149, 61, 5, 249, 81, 152, 0, 185, 89, 235, 17, 141, 220, 89, 45, 10, 100, 194, 124, 37, 91, 117, 253, 167, 91, 11, 149, 65, 192, 120, 88, 32, 254, 209, 90, 206, 36, 63, 79, 206, 17, 83, 18, 148, 4, 149, 246, 156, 147, 232, 78, 171 }, new byte[] { 98, 171, 119, 88, 129, 196, 155, 36, 76, 238, 142, 6, 100, 55, 178, 166, 216, 96, 120, 220, 8, 218, 193, 53, 142, 180, 245, 191, 69, 208, 170, 185, 44, 5, 18, 18, 243, 247, 134, 34, 139, 90, 219, 128, 93, 207, 65, 140, 132, 91, 160, 47, 36, 151, 79, 194, 65, 244, 212, 248, 148, 204, 60, 221, 205, 72, 21, 156, 238, 97, 34, 96, 72, 187, 82, 58, 16, 210, 84, 52, 194, 174, 228, 217, 89, 28, 1, 205, 57, 39, 182, 205, 83, 199, 96, 81, 227, 51, 24, 36, 53, 72, 11, 95, 38, 17, 65, 95, 73, 223, 10, 134, 239, 12, 25, 146, 203, 85, 6, 225, 164, 185, 121, 255, 226, 157, 196, 186 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1df15b96-2190-440a-8d86-f84c922dce55"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("23a1e832-287f-436b-8c2d-453d22471c0b") });
        }
    }
}
