using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Library.Infrastructure.Models;

public partial class Title
{
    public int Id { get; set; }

    public string Title1 { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<AuthorsTitle> AuthorsTitles { get; set; } = new List<AuthorsTitle>();

    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [JsonIgnore]
    public virtual ICollection<TitlesGender> TitlesGenders { get; set; } = new List<TitlesGender>();
}
