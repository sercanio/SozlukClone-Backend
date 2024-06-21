using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Entry : Entity<int>
{
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Dislike> Dislikes { get; set; }
    public ICollection<Favorite> Favorites { get; set; }

    public virtual Author Author { get; set; }
    public virtual Title Title { get; set; }
}
