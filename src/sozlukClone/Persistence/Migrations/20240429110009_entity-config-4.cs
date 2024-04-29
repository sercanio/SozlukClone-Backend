using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8bba1afb-8446-41fd-a900-bc858c3d93d7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("feed66ed-c41d-49a0-bf93-185119c553e2"));

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "Titles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Admin", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Read", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Write", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Create", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Update", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("ef2aa385-f947-4041-a3c0-b41405e5b2a1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 183, 87, 220, 112, 70, 73, 196, 3, 23, 44, 199, 144, 50, 202, 169, 221, 106, 223, 127, 61, 169, 195, 72, 148, 134, 47, 128, 191, 246, 46, 197, 227, 77, 137, 41, 155, 79, 43, 104, 108, 165, 102, 225, 52, 154, 65, 55, 114, 1, 115, 221, 245, 230, 211, 35, 187, 194, 87, 141, 44, 110, 56, 44, 201 }, new byte[] { 164, 98, 228, 255, 189, 2, 239, 89, 99, 160, 128, 209, 85, 107, 132, 89, 176, 14, 119, 190, 218, 129, 114, 170, 254, 220, 211, 247, 219, 196, 31, 93, 233, 107, 144, 100, 88, 72, 92, 169, 196, 127, 15, 68, 153, 220, 218, 33, 42, 240, 253, 235, 159, 102, 75, 28, 222, 20, 201, 233, 197, 190, 106, 71, 206, 99, 175, 240, 44, 202, 109, 174, 209, 243, 238, 20, 166, 11, 94, 202, 25, 15, 240, 87, 201, 80, 43, 54, 125, 101, 251, 166, 157, 81, 94, 145, 151, 112, 197, 163, 222, 117, 164, 141, 167, 63, 13, 131, 114, 89, 194, 167, 159, 169, 40, 130, 8, 91, 43, 182, 56, 123, 183, 131, 6, 195, 21, 140 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d38dafa7-5184-435a-a86e-024326ea5a03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ef2aa385-f947-4041-a3c0-b41405e5b2a1") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d38dafa7-5184-435a-a86e-024326ea5a03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef2aa385-f947-4041-a3c0-b41405e5b2a1"));

            migrationBuilder.DropColumn(
                name: "slug",
                table: "Titles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("feed66ed-c41d-49a0-bf93-185119c553e2"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 237, 2, 30, 149, 30, 178, 35, 68, 111, 188, 214, 161, 60, 171, 33, 18, 2, 166, 40, 72, 179, 66, 102, 92, 97, 66, 194, 144, 139, 118, 240, 172, 60, 55, 85, 6, 181, 104, 101, 129, 118, 114, 48, 232, 86, 184, 35, 46, 157, 104, 131, 21, 86, 234, 132, 100, 193, 146, 117, 1, 169, 227, 203, 190 }, new byte[] { 16, 119, 79, 109, 29, 193, 206, 233, 186, 188, 146, 214, 118, 25, 216, 47, 56, 209, 228, 44, 49, 194, 196, 112, 156, 129, 186, 130, 218, 243, 249, 94, 87, 8, 58, 187, 36, 149, 219, 193, 104, 17, 162, 140, 39, 90, 210, 225, 51, 53, 13, 90, 200, 14, 73, 139, 65, 91, 238, 253, 222, 227, 209, 227, 0, 107, 4, 51, 231, 178, 126, 157, 75, 120, 37, 125, 17, 35, 13, 155, 233, 150, 83, 13, 39, 14, 148, 29, 96, 250, 206, 207, 254, 213, 14, 121, 204, 209, 156, 39, 87, 166, 222, 164, 21, 117, 151, 107, 220, 183, 233, 162, 70, 101, 22, 147, 90, 17, 232, 253, 253, 45, 151, 20, 68, 98, 176, 79 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8bba1afb-8446-41fd-a900-bc858c3d93d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("feed66ed-c41d-49a0-bf93-185119c553e2") });
        }
    }
}
