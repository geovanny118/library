using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Models;

public partial class User
{
    public int Id { get; set; }

    public string Dni { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
