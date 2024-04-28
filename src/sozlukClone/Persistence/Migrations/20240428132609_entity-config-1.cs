using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a5768886-8965-4a2b-977d-350de4be6dfd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c81d876c-6ab8-472d-b5ec-1bf0b53cbcc1"));

            migrationBuilder.DropColumn(
                name: "TitleCount",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "BadgeId",
                table: "Authors",
                newName: "ActiveBadgeId");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Admin", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Read", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Write", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Create", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Update", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c973d93c-927c-4b4e-8726-72db2e2aac81"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 101, 127, 176, 98, 188, 255, 15, 1, 32, 66, 200, 199, 182, 24, 180, 157, 7, 38, 92, 239, 58, 136, 135, 132, 117, 49, 122, 80, 4, 164, 73, 217, 186, 112, 130, 96, 186, 122, 250, 155, 158, 187, 223, 177, 44, 22, 189, 118, 104, 29, 25, 193, 21, 234, 107, 222, 95, 106, 101, 137, 160, 134, 200, 111 }, new byte[] { 229, 71, 27, 226, 105, 66, 183, 212, 28, 34, 155, 74, 53, 139, 178, 155, 135, 222, 9, 86, 36, 210, 235, 148, 150, 189, 242, 67, 55, 98, 87, 168, 175, 248, 76, 230, 169, 51, 220, 255, 13, 229, 217, 184, 70, 223, 189, 7, 150, 169, 196, 183, 65, 153, 228, 173, 196, 181, 29, 183, 126, 53, 91, 142, 143, 158, 134, 117, 139, 125, 99, 97, 159, 230, 200, 207, 207, 221, 54, 97, 231, 38, 59, 158, 112, 93, 106, 188, 95, 8, 64, 110, 168, 186, 245, 47, 72, 108, 206, 178, 39, 132, 246, 129, 38, 34, 188, 149, 31, 205, 14, 195, 20, 183, 165, 180, 217, 238, 69, 224, 23, 226, 241, 251, 243, 112, 34, 31 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e5c5a971-bae6-4d09-8d0d-488614bbfe86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c973d93c-927c-4b4e-8726-72db2e2aac81") });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ActiveBadgeId",
                table: "Authors",
                column: "ActiveBadgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Badges_ActiveBadgeId",
                table: "Authors",
                column: "ActiveBadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Badges_ActiveBadgeId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_ActiveBadgeId",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e5c5a971-bae6-4d09-8d0d-488614bbfe86"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c973d93c-927c-4b4e-8726-72db2e2aac81"));

            migrationBuilder.RenameColumn(
                name: "ActiveBadgeId",
                table: "Authors",
                newName: "BadgeId");

            migrationBuilder.AddColumn<long>(
                name: "TitleCount",
                table: "Authors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c81d876c-6ab8-472d-b5ec-1bf0b53cbcc1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 100, 162, 207, 151, 84, 51, 155, 252, 21, 240, 15, 56, 201, 132, 104, 182, 140, 154, 129, 231, 86, 131, 18, 62, 51, 248, 191, 241, 89, 99, 80, 117, 215, 192, 136, 149, 163, 186, 254, 180, 211, 41, 22, 234, 5, 124, 171, 15, 197, 28, 64, 162, 134, 196, 166, 44, 101, 206, 143, 27, 52, 217, 21, 143 }, new byte[] { 225, 200, 28, 29, 85, 183, 179, 42, 93, 188, 103, 230, 6, 183, 57, 2, 127, 88, 78, 93, 90, 203, 141, 129, 214, 168, 103, 72, 172, 221, 69, 181, 89, 33, 215, 113, 171, 115, 45, 146, 224, 159, 2, 105, 221, 189, 188, 149, 225, 193, 240, 196, 224, 85, 103, 209, 171, 22, 70, 73, 39, 74, 206, 250, 190, 133, 236, 178, 237, 38, 242, 223, 49, 188, 188, 148, 64, 220, 168, 209, 251, 214, 206, 101, 107, 114, 58, 156, 80, 154, 230, 140, 58, 224, 139, 75, 40, 140, 180, 57, 166, 35, 214, 75, 35, 88, 129, 104, 114, 9, 245, 188, 64, 12, 180, 20, 48, 176, 203, 252, 250, 220, 53, 140, 112, 71, 133, 254 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a5768886-8965-4a2b-977d-350de4be6dfd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c81d876c-6ab8-472d-b5ec-1bf0b53cbcc1") });
        }
    }
}
