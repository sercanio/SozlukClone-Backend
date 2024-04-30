using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class AuthorGroupUserOperationClaim : Entity<Guid>
{
    public int OperationClaimId { get; set; }
    public int AuthorGroupId { get; set; }

    public virtual AuthorGroup AuthorGroup { get; set; } = default!;
    public virtual OperationClaim OperationClaim { get; set; } = default!;
}
