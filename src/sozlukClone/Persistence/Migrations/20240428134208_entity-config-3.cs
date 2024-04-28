using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityconfig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_PenaltyType_PenaltyTypeId",
                table: "Penalties");

            migrationBuilder.DropIndex(
                name: "IX_Penalties_PenaltyTypeId",
                table: "Penalties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PenaltyType",
                table: "PenaltyType");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("926f08c4-dc2b-44ec-b0b1-9bf9e7fe7952"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e411ec-c372-45dc-ac35-12c0314e055a"));

            migrationBuilder.RenameTable(
                name: "PenaltyType",
                newName: "PenaltyTypes");

            migrationBuilder.AddColumn<long>(
                name: "PenaltyTypeId1",
                table: "Penalties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Badges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorGroupId",
                table: "Authors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<long>(
                name: "ActiveBadgeId",
                table: "Authors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AuthorGroups",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "BadgesId",
                table: "AuthorBadge",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "PenaltyTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PenaltyTypes",
                table: "PenaltyTypes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Delete", null },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Admin", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Read", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Write", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Create", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Update", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Delete", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Admin", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Read", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Write", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Create", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Update", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Delete", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Admin", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Read", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Write", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Create", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Update", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("156b9e2b-7b86-4d22-85bd-90db518b0922"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 125, 0, 243, 175, 207, 240, 191, 184, 135, 106, 53, 55, 78, 37, 154, 165, 210, 9, 168, 160, 206, 154, 249, 178, 146, 239, 194, 31, 212, 130, 59, 191, 228, 60, 240, 40, 17, 251, 192, 108, 98, 246, 196, 124, 94, 213, 67, 72, 136, 168, 123, 138, 180, 63, 122, 124, 188, 218, 148, 253, 238, 181, 217, 22 }, new byte[] { 86, 49, 111, 63, 254, 45, 238, 122, 54, 68, 83, 92, 87, 143, 212, 104, 128, 98, 80, 154, 94, 85, 11, 195, 234, 219, 235, 154, 242, 28, 51, 255, 102, 241, 236, 207, 173, 82, 23, 93, 88, 28, 121, 201, 98, 165, 133, 238, 147, 228, 87, 241, 44, 42, 164, 240, 115, 6, 191, 5, 131, 40, 156, 213, 144, 171, 245, 81, 85, 202, 170, 172, 179, 85, 13, 87, 233, 122, 4, 4, 90, 194, 210, 188, 12, 23, 222, 89, 139, 127, 167, 141, 84, 35, 12, 119, 120, 235, 156, 3, 104, 202, 213, 184, 254, 192, 148, 13, 228, 202, 191, 135, 51, 84, 57, 133, 213, 9, 45, 203, 5, 236, 16, 75, 252, 44, 176, 173 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("243d8c43-76a8-4f25-a882-c5ce778f5ef4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("156b9e2b-7b86-4d22-85bd-90db518b0922") });

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_PenaltyTypeId1",
                table: "Penalties",
                column: "PenaltyTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_PenaltyTypes_PenaltyTypeId1",
                table: "Penalties",
                column: "PenaltyTypeId1",
                principalTable: "PenaltyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_PenaltyTypes_PenaltyTypeId1",
                table: "Penalties");

            migrationBuilder.DropIndex(
                name: "IX_Penalties_PenaltyTypeId1",
                table: "Penalties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PenaltyTypes",
                table: "PenaltyTypes");

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
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 97);

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
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("243d8c43-76a8-4f25-a882-c5ce778f5ef4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("156b9e2b-7b86-4d22-85bd-90db518b0922"));

            migrationBuilder.DropColumn(
                name: "PenaltyTypeId1",
                table: "Penalties");

            migrationBuilder.RenameTable(
                name: "PenaltyTypes",
                newName: "PenaltyType");

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "Badges",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<byte>(
                name: "AuthorGroupId",
                table: "Authors",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<byte>(
                name: "ActiveBadgeId",
                table: "Authors",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "AuthorGroups",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<byte>(
                name: "BadgesId",
                table: "AuthorBadge",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "PenaltyType",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PenaltyType",
                table: "PenaltyType",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("b9e411ec-c372-45dc-ac35-12c0314e055a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 146, 2, 188, 220, 26, 25, 186, 197, 214, 28, 226, 21, 236, 34, 194, 179, 196, 214, 105, 253, 14, 49, 170, 200, 42, 169, 29, 119, 196, 52, 142, 180, 203, 188, 173, 239, 48, 107, 116, 99, 196, 190, 238, 130, 195, 100, 253, 94, 103, 77, 87, 219, 156, 208, 0, 174, 3, 69, 196, 55, 39, 139, 25, 243 }, new byte[] { 176, 165, 63, 251, 12, 189, 135, 34, 240, 129, 70, 187, 37, 213, 0, 92, 87, 161, 140, 172, 61, 76, 134, 117, 52, 229, 43, 224, 229, 72, 196, 77, 7, 244, 240, 189, 4, 247, 205, 94, 128, 119, 208, 136, 52, 33, 96, 177, 49, 56, 122, 76, 48, 241, 191, 155, 57, 70, 191, 46, 153, 185, 139, 2, 97, 39, 213, 176, 78, 123, 3, 109, 150, 234, 164, 147, 30, 96, 182, 232, 38, 229, 233, 238, 238, 251, 94, 51, 104, 5, 132, 231, 231, 235, 203, 102, 3, 227, 53, 8, 227, 87, 17, 232, 139, 187, 60, 92, 225, 223, 247, 121, 18, 205, 42, 5, 254, 174, 165, 165, 206, 202, 70, 191, 156, 99, 106, 39 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("926f08c4-dc2b-44ec-b0b1-9bf9e7fe7952"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b9e411ec-c372-45dc-ac35-12c0314e055a") });

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_PenaltyTypeId",
                table: "Penalties",
                column: "PenaltyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_PenaltyType_PenaltyTypeId",
                table: "Penalties",
                column: "PenaltyTypeId",
                principalTable: "PenaltyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
