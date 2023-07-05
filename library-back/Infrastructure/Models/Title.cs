using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Models;

public partial class Title
{
    public int Id { get; set; }

    public string Title1 { get; set; } = null!;

    public virtual ICollection<AuthorsTitle> AuthorsTitles { get; set; } = new List<AuthorsTitle>();

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<TitlesGender> TitlesGenders { get; set; } = new List<TitlesGender>();
}
