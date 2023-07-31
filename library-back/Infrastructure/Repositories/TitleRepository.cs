using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Models;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories;

public class TitleRepository : ITitleRepository
{
    private readonly LibraryContext _context;

    public TitleRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Title>> GetAll()
    {
        return await _context.Titles
            .Include(t => t.TitlesGenders)
            .ThenInclude(tg => tg.Gender)
            .Include(t => t.AuthorsTitles)
            .ThenInclude(at => at.Author)
            .ToListAsync();
    }

    public async Task<Title> Search(int id)
    {
        return await _context.Titles
            .Include(t => t.TitlesGenders)
            .ThenInclude(tg => tg.Gender)
            .Include(t => t.AuthorsTitles)
            .ThenInclude(at => at.Author)
            .FirstOrDefaultAsync(e => e.Id == id) ?? null;
    }

    public async Task Create(Title entity)
    {
        await _context.Titles.AddAsync(entity);
    }

    public void Update(Title entity)
    {
        _context.Titles.Update(entity);
    }

    public void Delete(Title entity)
    {
        _context.Titles.Remove(entity);
    }
}