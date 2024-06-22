using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: false),
                    CoverPictureUrl = table.Column<string>(type: "text", nullable: false),
                    ActiveBadgeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IconUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PenaltyTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TitleSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SiteName = table.Column<string>(type: "text", nullable: true),
                    SiteDescription = table.Column<string>(type: "text", nullable: true),
                    SiteFavIcon = table.Column<string>(type: "text", nullable: true),
                    SiteLogo = table.Column<string>(type: "text", nullable: true),
                    SiteLogoFooter = table.Column<string>(type: "text", nullable: true),
                    SiteLogoMobile = table.Column<string>(type: "text", nullable: true),
                    MaxTitleLength = table.Column<int>(type: "integer", nullable: true),
                    DefaultAuthorGroupId = table.Column<int>(type: "integer", nullable: false),
                    IsAuthorRegistrationAllowed = table.Column<bool>(type: "boolean", nullable: true),
                    MaxEntryLength = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalSettings_AuthorGroups_DefaultAuthorGroupId",
                        column: x => x.DefaultAuthorGroupId,
                        principalTable: "AuthorGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorGroupUserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationClaimId = table.Column<int>(type: "integer", nullable: false),
                    AuthorGroupId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorGroupUserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorGroupUserOperationClaims_AuthorGroups_AuthorGroupId",
                        column: x => x.AuthorGroupId,
                        principalTable: "AuthorGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorGroupUserOperationClaims_OperationClaims_OperationCla~",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: true),
                    CoverPictureUrl = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<byte>(type: "smallint", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    AuthorGroupId = table.Column<int>(type: "integer", nullable: false),
                    ActiveBadgeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_AuthorGroups_AuthorGroupId",
                        column: x => x.AuthorGroupId,
                        principalTable: "AuthorGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authors_Badges_ActiveBadgeId",
                        column: x => x.ActiveBadgeId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivationKey = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "bytea", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationClaimId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBadge",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "integer", nullable: false),
                    BadgesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBadge", x => new { x.AuthorsId, x.BadgesId });
                    table.ForeignKey(
                        name: "FK_AuthorBadge_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBadge_Badges_BadgesId",
                        column: x => x.BadgesId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBlockings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockerId = table.Column<int>(type: "integer", nullable: false),
                    BlockingId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBlockings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorBlockings_Authors_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorBlockings_Authors_BlockingId",
                        column: x => x.BlockingId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorFollowings",
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
                    table.PrimaryKey("PK_AuthorFollowings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorFollowings_Authors_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorFollowings_Authors_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginAudits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastLoginIp = table.Column<string>(type: "text", nullable: false),
                    LastLoginLocation = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginAudits_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoginAudits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penalties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PenaltyTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    IssuerId = table.Column<int>(type: "integer", nullable: false),
                    PenaltyTypeId1 = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalties_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penalties_PenaltyTypes_PenaltyTypeId1",
                        column: x => x.PenaltyTypeId1,
                        principalTable: "PenaltyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    IsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorModOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    IssuerId = table.Column<int>(type: "integer", nullable: false),
                    PenaltyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorModOperations_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorModOperations_Authors_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorModOperations_Penalties_PenaltyId",
                        column: x => x.PenaltyId,
                        principalTable: "Penalties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    TitleId = table.Column<int>(type: "integer", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitleBlockings",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleBlockings", x => new { x.TitleId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_TitleBlockings_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleBlockings_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TitleCategory",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    TitleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleCategory", x => new { x.CategoryId, x.TitleId });
                    table.ForeignKey(
                        name: "FK_TitleCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleCategory_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitleFollowings",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleFollowings", x => new { x.TitleId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_TitleFollowings_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TitleFollowings_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TitleModOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TitleId = table.Column<int>(type: "integer", nullable: false),
                    IssuerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleModOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleModOperations_Authors_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleModOperations_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dislikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntryId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dislikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dislikes_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dislikes_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryModOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EntryId = table.Column<int>(type: "integer", nullable: false),
                    IssuerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryModOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryModOperations_Authors_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryModOperations_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntryId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntryId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorGroups",
                columns: new[] { "Id", "Color", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Developer", "Developer", null },
                    { 2, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SuperAdmin", "SuperAdmin", null },
                    { 3, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", "Admin", null },
                    { 4, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SuperModerator", "SuperModerator", null },
                    { 5, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Moderator", "Moderator", null },
                    { 6, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Editor", "Editor", null },
                    { 7, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Author", "Author", null },
                    { 8, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Guest", "Noob", null },
                    { 9, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suspended", "Suspended", null },
                    { 10, "#FFFFFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Banned", "Banned", null }
                });

            migrationBuilder.InsertData(
                table: "AuthorSettings",
                columns: new[] { "Id", "ActiveBadgeId", "CoverPictureUrl", "CreatedDate", "DeletedDate", "ProfilePictureUrl", "UpdatedDate" },
                values: new object[] { 1, 1, "default-cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "default-profile.png", null });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IconUrl", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Default", "default-icon.png", "Default", null });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Admin", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Read", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Write", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Create", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Update", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Delete", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Admin", null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Read", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Write", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Create", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Update", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Delete", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Admin", null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Read", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Write", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Create", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Update", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Delete", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Admin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Read", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Write", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Create", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Update", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Badges.Delete", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.Admin", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.Read", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.Write", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.Create", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.Update", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.Delete", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Penalties.Admin", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Penalties.Read", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Penalties.Write", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Penalties.Create", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Penalties.Update", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Penalties.Delete", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Admin", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Read", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Write", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Create", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Update", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PenaltyTypes.Delete", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LoginAudits.Admin", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LoginAudits.Read", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LoginAudits.Write", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LoginAudits.Create", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LoginAudits.Update", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LoginAudits.Delete", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Admin", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Read", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Write", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Create", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Update", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Delete", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Admin", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Read", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Write", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Create", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Update", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.Delete", null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleSettings.Admin", null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleSettings.Read", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleSettings.Write", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleSettings.Create", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleSettings.Update", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleSettings.Delete", null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorSettings.Admin", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorSettings.Read", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorSettings.Write", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorSettings.Create", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorSettings.Update", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorSettings.Delete", null },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroupUserOperationClaims.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroupUserOperationClaims.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroupUserOperationClaims.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroupUserOperationClaims.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroupUserOperationClaims.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroupUserOperationClaims.Delete", null },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.GetByUserName", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Admin", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Read", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Write", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Create", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Update", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorGroups.Delete", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Admin", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Read", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Write", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Create", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Update", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GlobalSettings.Delete", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.GetBySlug", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetListEntryHomePageQuery", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetListEntryForHomePage", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Titles.GetByTitleName", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetListByAuthorId", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Likes.Admin", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Likes.Read", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Likes.Write", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Likes.Create", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Likes.Update", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Likes.Delete", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dislikes.Admin", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dislikes.Read", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dislikes.Write", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dislikes.Create", null },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dislikes.Update", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dislikes.Delete", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Favorites.Admin", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Favorites.Read", null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Favorites.Write", null },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Favorites.Create", null },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Favorites.Update", null },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Favorites.Delete", null },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetTopLikedListByAuthorId", null },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entries.GetMostFavoritedListByAuthorId", null },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Admin", null },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Read", null },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Write", null },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Create", null },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Update", null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Delete", null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorFollowings.Admin", null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorFollowings.Read", null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorFollowings.Write", null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorFollowings.Create", null },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorFollowings.Update", null },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorFollowings.Delete", null },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorModOperations.Admin", null },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorModOperations.Read", null },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorModOperations.Write", null },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorModOperations.Create", null },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorModOperations.Update", null },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorModOperations.Delete", null },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EntryModOperations.Admin", null },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EntryModOperations.Read", null },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EntryModOperations.Write", null },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EntryModOperations.Create", null },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EntryModOperations.Update", null },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EntryModOperations.Delete", null },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleBlockings.Admin", null },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleBlockings.Read", null },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleBlockings.Write", null },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleBlockings.Create", null },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleBlockings.Update", null },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleBlockings.Delete", null },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleFollowings.Admin", null },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleFollowings.Read", null },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleFollowings.Write", null },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleFollowings.Create", null },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleFollowings.Update", null },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleFollowings.Delete", null },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleModOperations.Admin", null },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleModOperations.Read", null },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleModOperations.Write", null },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleModOperations.Create", null },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleModOperations.Update", null },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TitleModOperations.Delete", null },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Admin", null },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Read", null },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Write", null },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Create", null },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Update", null },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AuthorBlockings.Delete", null },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Admin", null },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Read", null },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Write", null },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Create", null },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Update", null },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "TitleSettings",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "MaxTitleLength", "MinTitleLength", "TitleCanHaveLink", "TitleCanHavePunctuation", "TitleCanHaveSpecialCharacter", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)50, (byte)1, false, false, true, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sozluk@email.com", new byte[] { 35, 170, 45, 108, 71, 6, 221, 239, 7, 125, 101, 228, 210, 96, 130, 95, 192, 88, 136, 4, 209, 58, 170, 243, 121, 27, 149, 63, 133, 189, 212, 54, 136, 157, 142, 152, 225, 155, 175, 93, 253, 166, 235, 158, 194, 230, 126, 5, 146, 251, 147, 112, 91, 191, 164, 191, 133, 22, 31, 19, 10, 46, 18, 150 }, new byte[] { 95, 137, 77, 194, 44, 45, 33, 180, 2, 213, 250, 239, 157, 192, 140, 71, 18, 132, 189, 71, 236, 151, 145, 142, 232, 159, 8, 133, 212, 26, 3, 30, 62, 112, 79, 72, 145, 160, 105, 183, 239, 157, 244, 191, 178, 24, 162, 171, 37, 156, 133, 89, 9, 179, 136, 207, 88, 129, 137, 69, 19, 39, 218, 169, 34, 230, 174, 251, 26, 227, 248, 4, 162, 65, 58, 114, 97, 11, 176, 20, 127, 101, 80, 136, 244, 73, 245, 128, 227, 77, 6, 75, 103, 3, 15, 137, 188, 41, 9, 245, 4, 249, 164, 169, 157, 110, 22, 173, 209, 157, 163, 7, 2, 116, 55, 163, 150, 214, 139, 231, 59, 171, 43, 169, 9, 79, 34, 246 }, null });

            migrationBuilder.InsertData(
                table: "AuthorGroupUserOperationClaims",
                columns: new[] { "Id", "AuthorGroupId", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate" },
                values: new object[] { new Guid("8acfb010-be5a-46d6-a750-87d4cb7765af"), 1, new DateTime(2024, 6, 22, 17, 49, 17, 247, DateTimeKind.Utc).AddTicks(3118), null, 1, null });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "ActiveBadgeId", "Age", "AuthorGroupId", "Biography", "CoverPictureUrl", "CreatedDate", "DeletedDate", "Gender", "ProfilePictureUrl", "UpdatedDate", "UserId", "UserName" },
                values: new object[] { 1, 1, null, 1, null, null, new DateTime(2024, 6, 22, 17, 49, 17, 246, DateTimeKind.Utc).AddTicks(4477), null, null, null, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6"), "sozluk" });

            migrationBuilder.InsertData(
                table: "GlobalSettings",
                columns: new[] { "Id", "CreatedDate", "DefaultAuthorGroupId", "DeletedDate", "IsAuthorRegistrationAllowed", "MaxEntryLength", "MaxTitleLength", "SiteDescription", "SiteFavIcon", "SiteLogo", "SiteLogoFooter", "SiteLogoMobile", "SiteName", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 6, 22, 17, 49, 17, 251, DateTimeKind.Utc).AddTicks(8055), 8, null, true, 5000, 50, "Default Description", "default-favicon.ico", "default-logo.png", "default-footer-logo.png", "default-mobile-logo.png", "Default Site", null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("77209001-5320-4f5b-ad19-9ab6ce7270ba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("029bf0d3-9429-44d7-9c30-51655e583ab6") });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "DeletedDate", "IsLocked", "Name", "Slug", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 22, 17, 49, 17, 254, DateTimeKind.Utc).AddTicks(7078), null, false, "sozlukclone projesi", "sozluk-clone-1", null });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedDate", "DeletedDate", "IsVisible", "TitleId", "UpdatedDate" },
                values: new object[] { 1, 1, "ASP.Net ve Nextjs ile geliştirilmiş bir sözlük klonudur.", new DateTime(2024, 6, 22, 17, 49, 17, 251, DateTimeKind.Utc).AddTicks(649), null, false, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBadge_BadgesId",
                table: "AuthorBadge",
                column: "BadgesId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBlockings_BlockerId",
                table: "AuthorBlockings",
                column: "BlockerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBlockings_BlockingId",
                table: "AuthorBlockings",
                column: "BlockingId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorFollowings_FollowerId",
                table: "AuthorFollowings",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorFollowings_FollowingId",
                table: "AuthorFollowings",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGroupUserOperationClaims_AuthorGroupId",
                table: "AuthorGroupUserOperationClaims",
                column: "AuthorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGroupUserOperationClaims_OperationClaimId",
                table: "AuthorGroupUserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModOperations_AuthorId",
                table: "AuthorModOperations",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModOperations_IssuerId",
                table: "AuthorModOperations",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModOperations_PenaltyId",
                table: "AuthorModOperations",
                column: "PenaltyId");

            migrationBuilder.CreateIndex(
                name: "Author_UserID_UK",
                table: "Authors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ActiveBadgeId",
                table: "Authors",
                column: "ActiveBadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorGroupId",
                table: "Authors",
                column: "AuthorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_Name",
                table: "Badges",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_AuthorId",
                table: "Dislikes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dislikes_EntryId",
                table: "Dislikes",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AuthorId",
                table: "Entries",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TitleId",
                table: "Entries",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryModOperations_EntryId",
                table: "EntryModOperations",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryModOperations_IssuerId",
                table: "EntryModOperations",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AuthorId",
                table: "Favorites",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_EntryId",
                table: "Favorites",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalSettings_DefaultAuthorGroupId",
                table: "GlobalSettings",
                column: "DefaultAuthorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AuthorId",
                table: "Likes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_EntryId",
                table: "Likes",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAudits_AuthorId",
                table: "LoginAudits",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAudits_UserId",
                table: "LoginAudits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_AuthorId",
                table: "Penalties",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_PenaltyTypeId1",
                table: "Penalties",
                column: "PenaltyTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleBlockings_AuthorId",
                table: "TitleBlockings",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleCategory_TitleId",
                table: "TitleCategory",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleFollowings_AuthorId",
                table: "TitleFollowings",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleModOperations_IssuerId",
                table: "TitleModOperations",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleModOperations_TitleId",
                table: "TitleModOperations",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_AuthorId",
                table: "Titles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBadge");

            migrationBuilder.DropTable(
                name: "AuthorBlockings");

            migrationBuilder.DropTable(
                name: "AuthorFollowings");

            migrationBuilder.DropTable(
                name: "AuthorGroupUserOperationClaims");

            migrationBuilder.DropTable(
                name: "AuthorModOperations");

            migrationBuilder.DropTable(
                name: "AuthorSettings");

            migrationBuilder.DropTable(
                name: "Dislikes");

            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "EntryModOperations");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "GlobalSettings");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "LoginAudits");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TitleBlockings");

            migrationBuilder.DropTable(
                name: "TitleCategory");

            migrationBuilder.DropTable(
                name: "TitleFollowings");

            migrationBuilder.DropTable(
                name: "TitleModOperations");

            migrationBuilder.DropTable(
                name: "TitleSettings");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Penalties");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "PenaltyTypes");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "AuthorGroups");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
