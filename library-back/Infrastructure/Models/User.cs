using System.Text.Json.Serialization;

namespace Library.Infrastructure.Models;

public partial class User
{
    public int Id { get; set; }

    public string Dni { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
