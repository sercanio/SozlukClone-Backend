using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c163ac4e-4937-408b-a9f4-bf5b78d09f85"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f0dc3672-089a-4923-ae58-c2dd6c035969"));

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AuthorGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "#FF0000");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "#00FF00");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "Color",
                value: "#0000FF");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "Color",
                value: "#FFFF00");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "Color",
                value: "#FF00FF");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "Color",
                value: "#00FFFF");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 7,
                column: "Color",
                value: "#C0C0C0");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "Color",
                value: "#808080");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 9,
                column: "Color",
                value: "#800000");

            migrationBuilder.UpdateData(
                table: "AuthorGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "Color",
                value: "#008000");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.GetByUserName", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("b7951240-6356-46f1-b7a5-d1034cd9dae0"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 159, 155, 205, 40, 19, 74, 159, 181, 160, 202, 243, 154, 219, 139, 174, 254, 72, 157, 51, 214, 222, 88, 82, 11, 62, 253, 168, 167, 70, 98, 191, 105, 78, 77, 115, 85, 167, 116, 234, 54, 50, 202, 13, 39, 126, 48, 40, 209, 208, 26, 52, 30, 48, 217, 173, 48, 97, 36, 61, 155, 134, 119, 237, 217 }, new byte[] { 119, 213, 15, 251, 193, 151, 131, 81, 103, 252, 104, 109, 231, 26, 156, 111, 110, 140, 146, 151, 59, 13, 7, 168, 253, 21, 105, 240, 139, 249, 130, 31, 110, 110, 88, 135, 212, 108, 5, 34, 14, 56, 159, 38, 136, 242, 62, 27, 167, 230, 217, 80, 238, 35, 252, 89, 121, 209, 191, 254, 122, 96, 70, 144, 129, 124, 31, 15, 68, 17, 240, 24, 197, 137, 84, 44, 150, 50, 18, 4, 107, 53, 74, 33, 149, 113, 68, 63, 136, 179, 218, 24, 67, 97, 10, 246, 197, 65, 86, 51, 232, 223, 248, 58, 245, 149, 1, 217, 141, 211, 69, 25, 192, 169, 39, 60, 36, 204, 214, 96, 207, 167, 236, 42, 21, 241, 237, 16 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7545f840-c50a-451d-b803-97f720d26678"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b7951240-6356-46f1-b7a5-d1034cd9dae0") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7545f840-c50a-451d-b803-97f720d26678"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b7951240-6356-46f1-b7a5-d1034cd9dae0"));

            migrationBuilder.DropColumn(
                name: "Color",
                table: "AuthorGroups");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f0dc3672-089a-4923-ae58-c2dd6c035969"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 122, 187, 153, 22, 30, 69, 235, 217, 101, 7, 142, 59, 46, 196, 58, 234, 35, 179, 45, 134, 169, 238, 36, 57, 119, 72, 234, 85, 91, 130, 222, 83, 33, 105, 31, 95, 16, 14, 215, 241, 2, 101, 89, 114, 141, 193, 143, 14, 155, 86, 144, 20, 227, 203, 134, 106, 194, 45, 160, 30, 30, 33, 49, 142 }, new byte[] { 174, 83, 16, 123, 216, 68, 9, 203, 27, 93, 57, 230, 221, 42, 241, 200, 156, 225, 36, 171, 227, 142, 226, 35, 80, 58, 121, 172, 143, 120, 145, 168, 85, 65, 75, 144, 241, 53, 251, 212, 162, 15, 184, 166, 208, 42, 157, 64, 149, 149, 107, 55, 180, 197, 114, 179, 29, 97, 214, 96, 236, 216, 59, 217, 40, 90, 15, 217, 47, 104, 155, 80, 98, 78, 71, 242, 189, 163, 230, 194, 201, 237, 171, 230, 172, 26, 252, 225, 68, 206, 66, 91, 52, 48, 162, 213, 155, 79, 145, 9, 201, 71, 44, 1, 54, 252, 88, 64, 175, 129, 152, 38, 55, 69, 219, 130, 235, 227, 165, 249, 1, 186, 29, 118, 173, 208, 41, 107 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c163ac4e-4937-408b-a9f4-bf5b78d09f85"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f0dc3672-089a-4923-ae58-c2dd6c035969") });
        }
    }
}
