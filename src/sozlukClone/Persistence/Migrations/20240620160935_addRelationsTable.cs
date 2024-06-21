using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRelationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5034847f-e6c2-4dba-9f2d-28c230e0c19d"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6a46e21e-8e58-42e7-9289-6ddc402ad571"));

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerId = table.Column<int>(type: "integer", nullable: false),
                    FollowingId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relations_Authors_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relations_Authors_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("c5bf34b6-4fcb-4620-ae3d-4c614c01d398"), 1, new DateTime(2024, 6, 20, 16, 9, 35, 86, DateTimeKind.Utc).AddTicks(4547), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 85, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 89, DateTimeKind.Utc).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 90, DateTimeKind.Utc).AddTicks(5607));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetListEntryHomePageQuery", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetListEntryForHomePage", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.GetByTitleName", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetListByAuthorId", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Relations.Admin", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Relations.Read", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Relations.Write", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Relations.Create", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Relations.Update", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Relations.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 20, 16, 9, 35, 94, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4112c50b-4038-4ddd-9703-01eebe4a8b80"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 30, 182, 38, 118, 8, 177, 237, 199, 125, 78, 157, 137, 127, 134, 42, 51, 48, 16, 174, 32, 110, 139, 16, 37, 200, 185, 48, 48, 60, 116, 94, 157, 164, 246, 54, 17, 118, 132, 192, 98, 21, 231, 78, 59, 143, 212, 70, 10, 176, 77, 202, 14, 143, 173, 112, 21, 154, 171, 209, 125, 153, 79, 116 }, new byte[] { 220, 233, 207, 40, 23, 6, 250, 182, 255, 89, 126, 27, 32, 49, 194, 90, 177, 73, 162, 56, 221, 179, 133, 196, 145, 83, 225, 151, 183, 164, 186, 207, 9, 84, 220, 112, 85, 172, 196, 117, 240, 208, 103, 83, 203, 4, 239, 52, 109, 4, 8, 127, 135, 128, 27, 192, 237, 95, 54, 81, 56, 137, 63, 101, 92, 122, 61, 199, 227, 133, 175, 72, 26, 87, 144, 18, 115, 150, 27, 63, 190, 156, 169, 199, 6, 25, 96, 145, 204, 224, 83, 250, 148, 80, 128, 7, 39, 155, 121, 78, 35, 31, 122, 253, 244, 247, 51, 39, 184, 77, 38, 105, 245, 232, 103, 63, 44, 123, 56, 182, 231, 167, 119, 84, 81, 30, 109, 211 } });

            migrationBuilder.CreateIndex(
                name: "IX_Relations_FollowerId",
                table: "Relations",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_FollowingId",
                table: "Relations",
                column: "FollowingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c5bf34b6-4fcb-4620-ae3d-4c614c01d398"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4112c50b-4038-4ddd-9703-01eebe4a8b80"));

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
                column: "CreatedDate",
                value: new DateTime(2024, 6, 16, 13, 46, 42, 555, DateTimeKind.Utc).AddTicks(1534));

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
    }
}
