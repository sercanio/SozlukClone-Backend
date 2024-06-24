using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateComplaintRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d85dba8b-c0f6-47ad-be27-d06a97e40c0e"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0b527f56-7ba5-43ed-9954-1ea9c2ff3a3e"));

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("5d4b11ea-af81-44de-a357-4260f9f6a02e"), 1, new DateTime(2024, 6, 24, 17, 6, 32, 949, DateTimeKind.Utc).AddTicks(4851), null, 1, null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 948, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 954, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "GlobalSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 955, DateTimeKind.Utc).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 17, 6, 32, 959, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d04b3b92-aab1-4a1c-9b8f-87ac9e4e00f2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 70, 231, 234, 60, 142, 181, 182, 250, 156, 96, 115, 174, 101, 168, 232, 73, 11, 75, 139, 219, 152, 34, 85, 138, 85, 249, 56, 198, 176, 10, 42, 89, 60, 158, 179, 20, 251, 11, 151, 204, 70, 252, 112, 84, 135, 199, 137, 95, 39, 231, 254, 169, 8, 248, 202, 176, 207, 157, 237, 111, 145, 199, 97 }, new byte[] { 159, 192, 78, 160, 108, 19, 134, 40, 52, 117, 24, 63, 47, 78, 70, 27, 199, 23, 134, 24, 31, 59, 252, 210, 160, 0, 198, 45, 41, 189, 196, 203, 62, 66, 5, 117, 66, 1, 196, 74, 107, 137, 251, 197, 45, 49, 254, 179, 58, 46, 194, 183, 125, 210, 77, 102, 13, 21, 202, 80, 65, 48, 189, 17, 142, 225, 105, 238, 74, 222, 206, 118, 59, 187, 95, 233, 152, 97, 17, 238, 22, 78, 250, 41, 6, 93, 27, 217, 102, 150, 245, 5, 221, 25, 228, 173, 139, 136, 193, 123, 246, 226, 31, 233, 191, 31, 71, 221, 89, 34, 44, 246, 106, 23, 7, 172, 231, 171, 148, 79, 50, 133, 7, 35, 152, 99, 22, 180 } });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_EntryId",
                table: "Complaints",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Entries_EntryId",
                table: "Complaints",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Entries_EntryId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_EntryId",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "AuthorGroupUserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5d4b11ea-af81-44de-a357-4260f9f6a02e"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d04b3b92-aab1-4a1c-9b8f-87ac9e4e00f2"));

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
        }
    }
}
