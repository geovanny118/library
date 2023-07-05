using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class AuthorsTitle
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int TitleId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
