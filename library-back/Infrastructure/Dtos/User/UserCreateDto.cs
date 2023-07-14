namespace Library.Infrastructure.Dtos;

public class UserCreateDto
{
    public string Dni { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
}