using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("49de5578-12fd-408e-8233-472a2ba93616"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44bf182a-abba-4d62-aa28-a2ab00ab52be"));

            migrationBuilder.CreateTable(
                name: "RegisterAudits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterAudits_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RegisterAudits.Delete", null }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RegisterAudits_UserId",
                table: "RegisterAudits",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d5338088-6cf0-4f47-ac60-6427de1457e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf1814b2-b4b4-4709-80b9-8945b9787cd2"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("44bf182a-abba-4d62-aa28-a2ab00ab52be"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 70, 228, 187, 226, 115, 21, 185, 38, 112, 175, 78, 156, 187, 59, 6, 40, 178, 112, 250, 8, 226, 66, 150, 106, 108, 218, 223, 57, 162, 201, 243, 148, 232, 141, 216, 35, 233, 89, 238, 49, 220, 253, 166, 8, 99, 200, 201, 168, 93, 82, 175, 164, 191, 34, 142, 192, 239, 8, 13, 215, 209, 219, 110, 202 }, new byte[] { 140, 210, 76, 174, 205, 182, 126, 255, 181, 2, 13, 111, 23, 1, 92, 101, 188, 70, 193, 95, 49, 48, 195, 118, 10, 218, 124, 168, 3, 196, 4, 68, 227, 41, 86, 124, 180, 224, 116, 68, 47, 24, 102, 194, 170, 122, 162, 191, 182, 245, 105, 151, 21, 218, 85, 127, 87, 175, 194, 57, 32, 108, 242, 103, 41, 146, 235, 254, 206, 63, 116, 135, 135, 234, 170, 89, 135, 213, 208, 79, 64, 206, 118, 245, 87, 161, 27, 3, 181, 96, 13, 164, 61, 130, 212, 53, 3, 135, 157, 70, 175, 73, 212, 131, 251, 158, 2, 167, 128, 52, 128, 13, 235, 253, 226, 120, 110, 13, 2, 57, 250, 97, 185, 89, 56, 68, 217, 249 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("49de5578-12fd-408e-8233-472a2ba93616"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("44bf182a-abba-4d62-aa28-a2ab00ab52be") });
        }
    }
}
