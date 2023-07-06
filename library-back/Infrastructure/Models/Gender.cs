using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library.Infrastructure.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string Gender1 { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<TitlesGender> TitlesGenders { get; set; } = new List<TitlesGender>();
}
