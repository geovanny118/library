namespace Library.Infrastructure.Dtos;

public class BookResponseDto
{
    public int Id { get; set; }

    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;
}