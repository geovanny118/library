using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Models;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository 
{
    private readonly LibraryContext _context;

    public AuthorRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetByIdAsync(int id)
    {
        return (await _context!.Authors!.FirstOrDefaultAsync(e => e.Id == id) ?? null) ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Author entity)
    {
        await _context.Authors.AddAsync(entity);
    }

    public void Update(Author entity)
    {
        _context.Authors.Update(entity);
    }

    public void Delete(Author entity)
    {
        _context.Authors.Remove(entity);
    }
}