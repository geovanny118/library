using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Nationality { get; set; }

    public virtual ICollection<AuthorsTitle> AuthorsTitles { get; set; } = new List<AuthorsTitle>();
}
