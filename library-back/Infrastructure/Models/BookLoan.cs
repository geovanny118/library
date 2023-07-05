using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Models;

public partial class BookLoan
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int? Amount { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
