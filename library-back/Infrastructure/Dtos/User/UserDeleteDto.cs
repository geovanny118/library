namespace Library.Infrastructure.Dtos;

public class UserDeleteDto
{
    public int Id { get; set; }

    public string Dni { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
}