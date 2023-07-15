namespace Library.Infrastructure.Dtos;

public class BookUpdateDto
{
    public int Id { get; set; }

    public int TitleId { get; set; }

    public string Isbn { get; set; } = null!;
}