using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateComplaintsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a01da53d-64bf-44a9-92c8-10ec3b9d0819"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("91133532-b8b6-4698-b831-a76d148ea354"));

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TitleId = table.Column<int>(type: "integer", nullable: false),
                    EntryId = table.Column<int>(type: "integer", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complaints_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("d85dba8b-c0f6-47ad-be27-d06a97e40c0e"), 1, new DateTime(2024, 6, 24, 15, 12, 15, 292, DateTimeKind.Utc).AddTicks(7792), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 15, 12, 15, 290, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 15, 12, 15, 298, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 15, 12, 15, 299, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Complaints.Admin", null },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Complaints.Read", null },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Complaints.Write", null },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Complaints.Create", null },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Complaints.Update", null },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Complaints.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 15, 12, 15, 302, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0b527f56-7ba5-43ed-9954-1ea9c2ff3a3e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 149, 43, 77, 196, 147, 210, 222, 203, 23, 91, 194, 11, 149, 158, 105, 249, 156, 209, 83, 211, 19, 111, 83, 89, 236, 39, 88, 197, 219, 15, 123, 123, 32, 45, 82, 129, 116, 210, 105, 127, 18, 176, 6, 163, 37, 192, 164, 30, 216, 202, 143, 255, 151, 176, 78, 39, 52, 220, 215, 64, 220, 87, 108, 86 }, new byte[] { 147, 158, 182, 160, 106, 123, 234, 122, 10, 187, 156, 122, 206, 255, 125, 237, 34, 86, 163, 146, 129, 122, 147, 202, 82, 126, 103, 164, 183, 198, 190, 110, 90, 30, 127, 16, 123, 11, 54, 78, 145, 54, 218, 0, 164, 109, 111, 65, 100, 4, 67, 148, 143, 246, 211, 177, 196, 221, 52, 30, 236, 42, 161, 141, 94, 50, 172, 222, 223, 186, 247, 4, 78, 164, 3, 137, 136, 234, 104, 232, 250, 254, 6, 248, 15, 7, 8, 178, 138, 236, 241, 252, 213, 17, 153, 163, 83, 215, 161, 1, 65, 97, 174, 243, 65, 70, 107, 9, 220, 73, 113, 69, 175, 243, 156, 7, 186, 219, 11, 177, 144, 64, 172, 111, 126, 199, 77, 166 } });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AuthorId",
                table: "Complaints",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_TitleId",
                table: "Complaints",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d85dba8b-c0f6-47ad-be27-d06a97e40c0e"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0b527f56-7ba5-43ed-9954-1ea9c2ff3a3e"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("a01da53d-64bf-44a9-92c8-10ec3b9d0819"), 1, new DateTime(2024, 6, 24, 12, 2, 54, 217, DateTimeKind.Utc).AddTicks(6678), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 216, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 223, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 223, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 12, 2, 54, 226, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("91133532-b8b6-4698-b831-a76d148ea354"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 208, 230, 188, 185, 126, 200, 45, 36, 92, 21, 65, 7, 5, 83, 202, 70, 242, 121, 36, 45, 21, 31, 158, 88, 104, 253, 209, 247, 153, 212, 240, 107, 80, 47, 189, 171, 23, 249, 37, 170, 84, 232, 0, 4, 210, 229, 205, 41, 112, 122, 103, 138, 150, 193, 108, 29, 198, 0, 176, 51, 35, 23, 23, 175 }, new byte[] { 126, 78, 214, 191, 159, 199, 7, 190, 174, 63, 46, 255, 209, 77, 216, 211, 87, 154, 236, 49, 118, 224, 81, 26, 186, 170, 162, 129, 2, 201, 182, 111, 254, 49, 233, 1, 183, 178, 223, 19, 172, 57, 251, 133, 66, 244, 186, 150, 233, 57, 235, 203, 28, 200, 92, 59, 46, 112, 171, 28, 114, 36, 187, 243, 27, 99, 194, 202, 201, 54, 51, 116, 244, 244, 39, 21, 230, 104, 179, 70, 208, 183, 1, 184, 94, 201, 17, 36, 108, 254, 101, 126, 50, 133, 73, 57, 82, 21, 17, 55, 233, 62, 114, 156, 248, 9, 42, 152, 230, 245, 67, 90, 12, 32, 64, 16, 80, 175, 162, 200, 116, 233, 84, 160, 188, 232, 46, 179 } });
        }
    }
}
