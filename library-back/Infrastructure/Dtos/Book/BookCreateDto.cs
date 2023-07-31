using Library.Infrastructure.Models;

namespace Library.Infrastructure.Dtos;

public class BookCreateDto
{
    public int TitleId { get; set; }

    public string Isbn { get; set; } = null!;
}