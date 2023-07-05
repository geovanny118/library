using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Models;

public partial class TitlesGender
{
    public int Id { get; set; }

    public int TitleId { get; set; }

    public int GenderId { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
