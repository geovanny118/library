using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Book
{
    public int Id { get; set; }

    public int TitleId { get; set; }

    public string Isbn { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Title Title { get; set; } = null!;
}
