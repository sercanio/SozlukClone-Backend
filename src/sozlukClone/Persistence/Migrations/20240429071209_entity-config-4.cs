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
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterAudits_Authors_AuthorId",
                table: "RegisterAudits");

            migrationBuilder.DropIndex(
                name: "IX_RegisterAudits_AuthorId",
                table: "RegisterAudits");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d5338088-6cf0-4f47-ac60-6427de1457e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf1814b2-b4b4-4709-80b9-8945b9787cd2"));

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "RegisterAudits");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "RegisterAudits");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Admin", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Read", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Write", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Create", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Update", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Delete", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Admin", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Read", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Write", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Create", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Update", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("7dbb75a6-14a0-4fda-98fa-f3d615d1c0d4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 104, 58, 124, 243, 80, 205, 102, 175, 218, 141, 62, 157, 32, 251, 155, 9, 45, 33, 23, 169, 224, 15, 231, 194, 83, 157, 1, 40, 23, 245, 45, 253, 72, 168, 36, 43, 224, 220, 81, 246, 95, 92, 164, 187, 73, 244, 223, 123, 43, 223, 11, 133, 182, 85, 91, 13, 245, 47, 11, 82, 152, 141, 167, 29 }, new byte[] { 20, 24, 134, 71, 163, 124, 125, 120, 225, 41, 9, 243, 49, 154, 87, 68, 150, 158, 16, 42, 119, 180, 193, 204, 141, 166, 93, 202, 168, 130, 196, 55, 164, 219, 168, 119, 254, 1, 194, 44, 140, 82, 244, 222, 230, 252, 8, 49, 130, 218, 82, 109, 117, 186, 47, 145, 75, 117, 92, 252, 43, 207, 127, 210, 123, 92, 52, 198, 88, 242, 208, 122, 128, 206, 152, 48, 177, 75, 146, 94, 166, 239, 200, 57, 36, 35, 128, 5, 177, 15, 48, 202, 88, 51, 248, 50, 53, 8, 155, 77, 63, 173, 221, 184, 227, 185, 132, 75, 189, 31, 243, 27, 143, 211, 68, 200, 211, 140, 123, 232, 56, 137, 56, 199, 32, 39, 205, 238 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b05decce-f156-4da8-a79e-721bd69f21b7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7dbb75a6-14a0-4fda-98fa-f3d615d1c0d4") });
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
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b05decce-f156-4da8-a79e-721bd69f21b7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7dbb75a6-14a0-4fda-98fa-f3d615d1c0d4"));

            migrationBuilder.AddColumn<long>(
                name: "AuthorId",
                table: "RegisterAudits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "RegisterAudits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("cf1814b2-b4b4-4709-80b9-8945b9787cd2"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 155, 79, 68, 212, 62, 17, 38, 163, 3, 237, 71, 42, 28, 42, 108, 110, 32, 126, 204, 193, 0, 188, 160, 10, 224, 192, 14, 254, 170, 234, 97, 244, 252, 36, 126, 140, 19, 51, 122, 223, 57, 13, 107, 119, 217, 184, 72, 28, 11, 4, 156, 22, 234, 107, 166, 142, 116, 21, 107, 234, 235, 248, 18, 114 }, new byte[] { 83, 26, 147, 80, 125, 54, 91, 146, 191, 12, 102, 103, 15, 63, 255, 37, 169, 49, 116, 205, 3, 208, 173, 21, 133, 103, 82, 95, 68, 174, 194, 161, 185, 64, 164, 64, 198, 212, 36, 135, 200, 212, 223, 136, 13, 209, 116, 76, 88, 144, 181, 242, 52, 44, 189, 207, 77, 251, 216, 128, 223, 53, 49, 64, 27, 32, 38, 238, 158, 148, 157, 71, 9, 241, 231, 2, 117, 102, 193, 117, 3, 42, 154, 248, 76, 233, 219, 231, 196, 48, 79, 197, 56, 82, 226, 24, 155, 154, 238, 212, 32, 47, 248, 244, 146, 36, 116, 213, 50, 61, 90, 89, 134, 254, 212, 60, 147, 180, 12, 210, 252, 255, 179, 122, 91, 242, 7, 50 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d5338088-6cf0-4f47-ac60-6427de1457e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("cf1814b2-b4b4-4709-80b9-8945b9787cd2") });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterAudits_AuthorId",
                table: "RegisterAudits",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterAudits_Authors_AuthorId",
                table: "RegisterAudits",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
