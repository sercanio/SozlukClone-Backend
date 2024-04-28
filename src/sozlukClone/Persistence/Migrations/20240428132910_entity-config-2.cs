using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                keyValue: new Guid("e5c5a971-bae6-4d09-8d0d-488614bbfe86"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c973d93c-927c-4b4e-8726-72db2e2aac81"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Authors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("b9e411ec-c372-45dc-ac35-12c0314e055a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 146, 2, 188, 220, 26, 25, 186, 197, 214, 28, 226, 21, 236, 34, 194, 179, 196, 214, 105, 253, 14, 49, 170, 200, 42, 169, 29, 119, 196, 52, 142, 180, 203, 188, 173, 239, 48, 107, 116, 99, 196, 190, 238, 130, 195, 100, 253, 94, 103, 77, 87, 219, 156, 208, 0, 174, 3, 69, 196, 55, 39, 139, 25, 243 }, new byte[] { 176, 165, 63, 251, 12, 189, 135, 34, 240, 129, 70, 187, 37, 213, 0, 92, 87, 161, 140, 172, 61, 76, 134, 117, 52, 229, 43, 224, 229, 72, 196, 77, 7, 244, 240, 189, 4, 247, 205, 94, 128, 119, 208, 136, 52, 33, 96, 177, 49, 56, 122, 76, 48, 241, 191, 155, 57, 70, 191, 46, 153, 185, 139, 2, 97, 39, 213, 176, 78, 123, 3, 109, 150, 234, 164, 147, 30, 96, 182, 232, 38, 229, 233, 238, 238, 251, 94, 51, 104, 5, 132, 231, 231, 235, 203, 102, 3, 227, 53, 8, 227, 87, 17, 232, 139, 187, 60, 92, 225, 223, 247, 121, 18, 205, 42, 5, 254, 174, 165, 165, 206, 202, 70, 191, 156, 99, 106, 39 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("926f08c4-dc2b-44ec-b0b1-9bf9e7fe7952"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b9e411ec-c372-45dc-ac35-12c0314e055a") });

            migrationBuilder.CreateIndex(
                name: "Author_UserID_UK",
                table: "Authors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_UserId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "Author_UserID_UK",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("926f08c4-dc2b-44ec-b0b1-9bf9e7fe7952"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e411ec-c372-45dc-ac35-12c0314e055a"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Authors");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c973d93c-927c-4b4e-8726-72db2e2aac81"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 101, 127, 176, 98, 188, 255, 15, 1, 32, 66, 200, 199, 182, 24, 180, 157, 7, 38, 92, 239, 58, 136, 135, 132, 117, 49, 122, 80, 4, 164, 73, 217, 186, 112, 130, 96, 186, 122, 250, 155, 158, 187, 223, 177, 44, 22, 189, 118, 104, 29, 25, 193, 21, 234, 107, 222, 95, 106, 101, 137, 160, 134, 200, 111 }, new byte[] { 229, 71, 27, 226, 105, 66, 183, 212, 28, 34, 155, 74, 53, 139, 178, 155, 135, 222, 9, 86, 36, 210, 235, 148, 150, 189, 242, 67, 55, 98, 87, 168, 175, 248, 76, 230, 169, 51, 220, 255, 13, 229, 217, 184, 70, 223, 189, 7, 150, 169, 196, 183, 65, 153, 228, 173, 196, 181, 29, 183, 126, 53, 91, 142, 143, 158, 134, 117, 139, 125, 99, 97, 159, 230, 200, 207, 207, 221, 54, 97, 231, 38, 59, 158, 112, 93, 106, 188, 95, 8, 64, 110, 168, 186, 245, 47, 72, 108, 206, 178, 39, 132, 246, 129, 38, 34, 188, 149, 31, 205, 14, 195, 20, 183, 165, 180, 217, 238, 69, 224, 23, 226, 241, 251, 243, 112, 34, 31 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e5c5a971-bae6-4d09-8d0d-488614bbfe86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c973d93c-927c-4b4e-8726-72db2e2aac81") });
        }
    }
}
