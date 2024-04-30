using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d38dafa7-5184-435a-a86e-024326ea5a03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef2aa385-f947-4041-a3c0-b41405e5b2a1"));

            migrationBuilder.CreateTable(
                name: "TitleSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinTitleLength = table.Column<byte>(type: "smallint", nullable: false),
                    MaxTitleLength = table.Column<byte>(type: "smallint", nullable: false),
                    TitleCanHaveLink = table.Column<bool>(type: "boolean", nullable: false),
                    TitleCanHaveSpecialCharacter = table.Column<bool>(type: "boolean", nullable: false),
                    TitleCanHavePunctuation = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleSettings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "TitleSettings.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "TitleSettings.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "TitleSettings.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "TitleSettings.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "TitleSettings.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "TitleSettings.Delete");

            migrationBuilder.InsertData(
                table: "TitleSettings",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "MaxTitleLength", "MinTitleLength", "TitleCanHaveLink", "TitleCanHavePunctuation", "TitleCanHaveSpecialCharacter", "UpdatedDate" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)50, (byte)1, false, false, true, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("8d33c656-d9ea-4f13-94b2-b5755f42f230"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 191, 122, 104, 233, 232, 67, 92, 57, 169, 225, 123, 110, 109, 225, 105, 202, 108, 68, 63, 205, 231, 47, 252, 249, 64, 68, 131, 233, 160, 73, 79, 88, 54, 119, 29, 245, 137, 32, 225, 248, 37, 185, 179, 230, 234, 248, 90, 68, 96, 43, 67, 2, 252, 87, 46, 199, 253, 32, 165, 89, 176, 61, 63, 173 }, new byte[] { 121, 62, 84, 170, 208, 105, 84, 55, 248, 5, 41, 214, 136, 104, 172, 126, 8, 44, 17, 95, 191, 198, 80, 105, 235, 140, 132, 248, 63, 5, 209, 67, 7, 90, 218, 178, 12, 145, 237, 26, 73, 103, 237, 124, 92, 9, 249, 18, 218, 24, 166, 219, 96, 234, 186, 76, 43, 190, 12, 111, 153, 75, 253, 39, 9, 140, 149, 209, 108, 31, 217, 168, 88, 213, 73, 93, 121, 118, 171, 78, 98, 128, 74, 162, 121, 16, 164, 152, 165, 13, 240, 157, 49, 143, 64, 183, 204, 172, 158, 215, 235, 123, 59, 11, 197, 56, 102, 21, 94, 117, 43, 216, 200, 73, 205, 17, 129, 76, 151, 46, 134, 236, 152, 109, 249, 11, 74, 75 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("92cb515c-65ae-4965-b3bf-ba8e5c8af7f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8d33c656-d9ea-4f13-94b2-b5755f42f230") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TitleSettings");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("92cb515c-65ae-4965-b3bf-ba8e5c8af7f4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d33c656-d9ea-4f13-94b2-b5755f42f230"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "Titles.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Titles.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Titles.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Titles.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Titles.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Titles.Delete");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("ef2aa385-f947-4041-a3c0-b41405e5b2a1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 183, 87, 220, 112, 70, 73, 196, 3, 23, 44, 199, 144, 50, 202, 169, 221, 106, 223, 127, 61, 169, 195, 72, 148, 134, 47, 128, 191, 246, 46, 197, 227, 77, 137, 41, 155, 79, 43, 104, 108, 165, 102, 225, 52, 154, 65, 55, 114, 1, 115, 221, 245, 230, 211, 35, 187, 194, 87, 141, 44, 110, 56, 44, 201 }, new byte[] { 164, 98, 228, 255, 189, 2, 239, 89, 99, 160, 128, 209, 85, 107, 132, 89, 176, 14, 119, 190, 218, 129, 114, 170, 254, 220, 211, 247, 219, 196, 31, 93, 233, 107, 144, 100, 88, 72, 92, 169, 196, 127, 15, 68, 153, 220, 218, 33, 42, 240, 253, 235, 159, 102, 75, 28, 222, 20, 201, 233, 197, 190, 106, 71, 206, 99, 175, 240, 44, 202, 109, 174, 209, 243, 238, 20, 166, 11, 94, 202, 25, 15, 240, 87, 201, 80, 43, 54, 125, 101, 251, 166, 157, 81, 94, 145, 151, 112, 197, 163, 222, 117, 164, 141, 167, 63, 13, 131, 114, 89, 194, 167, 159, 169, 40, 130, 8, 91, 43, 182, 56, 123, 183, 131, 6, 195, 21, 140 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d38dafa7-5184-435a-a86e-024326ea5a03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ef2aa385-f947-4041-a3c0-b41405e5b2a1") });
        }
    }
}
