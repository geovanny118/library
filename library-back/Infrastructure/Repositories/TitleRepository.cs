using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Title>> GetAllAsync()
    {
        return await _context.Titles.ToListAsync();
    }

    public async Task<Title> GetByIdAsync(int id)
    {
        return await _context!.Titles!.FirstOrDefaultAsync(e => e.Id == id) ?? null;
    }

    public async Task AddAsync(Title entity)
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