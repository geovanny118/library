using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<TitlesGender> TitlesGenders { get; set; } = new List<TitlesGender>();
}
