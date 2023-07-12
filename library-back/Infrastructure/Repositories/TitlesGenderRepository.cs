using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Models;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories;

public class TitlesGenderRepository : ITitlesGenderRepository
{
    private readonly LibraryContext _context;

    public TitlesGenderRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TitlesGender>> GetAllAsync()
    {
        return await _context.TitlesGenders.ToListAsync();
    }

    public async Task<TitlesGender> GetByIdAsync(int id)
    {
        return (await _context!.TitlesGenders!.FirstOrDefaultAsync(e => e.Id == id) ?? null) ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(TitlesGender entity)
    {
        await _context.TitlesGenders.AddAsync(entity);
    }

    public void Update(TitlesGender entity)
    {
        _context.TitlesGenders.Update(entity);
    }

    public void Delete(TitlesGender entity)
    {
        _context.TitlesGenders.Remove(entity);
    }
}