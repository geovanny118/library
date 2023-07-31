namespace Library.Infrastructure.Dtos;

public class TitleResponseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    
    public string? Author { get; set; }
    
    public ICollection<string>? Genders { get; set; }
}