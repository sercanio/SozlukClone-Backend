using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorGroup> AuthorGroups { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<Penalty> Penalties { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<PenaltyType> PenaltyTypes { get; set; }
    public DbSet<LoginAudit> LoginAudits { get; set; }
    public DbSet<TitleSetting> TitleSettings { get; set; }
    public DbSet<AuthorSetting> AuthorSettings { get; set; }
    public DbSet<AuthorGroupUserOperationClaim> AuthorGroupUserOperationClaims { get; set; }
    public DbSet<GlobalSetting> Settings { get; set; }
    public DbSet<GlobalSetting> GlobalSettings { get; set; }
    public DbSet<AuthorFollowing> AuthorFollowings { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Dislike> Dislikes { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<AuthorBlocking> AuthorBlockings { get; set; }
    public DbSet<AuthorModOperation> AuthorModOperations { get; set; }
    public DbSet<EntryModOperation> EntryModOperations { get; set; }
    public DbSet<TitleBlocking> TitleBlockings { get; set; }
    public DbSet<TitleFollowing> TitleFollowings { get; set; }
    public DbSet<TitleModOperation> TitleModOperations { get; set; }
    public DbSet<Category> Categories { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
