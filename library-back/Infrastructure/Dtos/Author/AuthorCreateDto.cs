namespace Infrastructure.Dtos.Author;

public class AuthorCreateDto
{
    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Nationality { get; set; }
}