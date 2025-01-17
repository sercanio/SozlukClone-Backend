﻿using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Badge : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
}
