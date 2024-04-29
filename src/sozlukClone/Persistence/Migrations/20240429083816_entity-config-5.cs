using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterAudits");

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("2841d1e6-bdc6-42fe-aa4e-868dd16b8b08"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 175, 64, 4, 0, 42, 197, 72, 87, 127, 22, 179, 99, 96, 194, 27, 242, 129, 240, 121, 239, 70, 209, 94, 253, 33, 140, 86, 186, 105, 225, 85, 152, 125, 173, 158, 172, 125, 178, 228, 122, 179, 119, 214, 41, 163, 36, 213, 252, 128, 234, 113, 122, 17, 246, 245, 130, 148, 200, 193, 5, 10, 21, 110, 71 }, new byte[] { 187, 158, 18, 44, 167, 135, 184, 116, 61, 45, 187, 100, 234, 153, 124, 41, 164, 56, 186, 115, 3, 130, 215, 145, 254, 152, 134, 116, 94, 77, 49, 211, 143, 51, 149, 40, 36, 231, 116, 120, 178, 213, 183, 201, 120, 211, 36, 185, 172, 22, 165, 159, 118, 197, 107, 71, 1, 58, 128, 197, 196, 113, 212, 121, 8, 28, 196, 21, 236, 154, 22, 214, 141, 113, 77, 116, 205, 152, 104, 153, 76, 240, 10, 20, 210, 143, 97, 224, 35, 5, 107, 143, 24, 53, 200, 124, 0, 170, 123, 24, 247, 178, 96, 149, 128, 229, 125, 197, 97, 249, 196, 40, 131, 187, 90, 158, 33, 222, 11, 202, 112, 73, 132, 70, 128, 163, 246, 123 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("389bc87f-856d-4a47-a929-92dfed57d4c1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2841d1e6-bdc6-42fe-aa4e-868dd16b8b08") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("389bc87f-856d-4a47-a929-92dfed57d4c1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2841d1e6-bdc6-42fe-aa4e-868dd16b8b08"));

            migrationBuilder.CreateTable(
                name: "RegisterAudits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterAudits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Delete", null },
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

            migrationBuilder.CreateIndex(
                name: "IX_RegisterAudits_UserId",
                table: "RegisterAudits",
                column: "UserId");
        }
    }
}
