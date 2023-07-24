using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Models;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories;

public class AuthorTitleRepository : IAuthorTitleRepository
{
    private readonly LibraryContext _context;

    public AuthorTitleRepository(LibraryContext context)
    {
        _context = context;
    }
    
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<AuthorsTitle>> GetAll()
    {
        return await _context.AuthorsTitles.ToListAsync();
    }

    public async Task<AuthorsTitle> Search(int id)
    {
        return (await _context!.AuthorsTitles!.FirstOrDefaultAsync(e => e.Id == id) ?? null) ?? throw new InvalidOperationException();
    }

    public async Task Create(AuthorsTitle entity)
    {
        await _context.AuthorsTitles.AddAsync(entity);
    }

    public void Update(AuthorsTitle entity)
    {
        _context.AuthorsTitles.Update(entity);
    }

    public void Delete(AuthorsTitle entity)
    {
        _context.AuthorsTitles.Remove(entity);
    }
}