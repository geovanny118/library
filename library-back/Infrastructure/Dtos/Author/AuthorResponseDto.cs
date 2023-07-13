namespace Library.Infrastructure.Dtos;

public class AuthorResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Nationality { get; set; }
}