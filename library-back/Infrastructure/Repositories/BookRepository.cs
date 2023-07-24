using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Models;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _context.Books.Include(b => b.Title).ToListAsync();
    }

    public async Task<Book> Search(int id)
    {
        return await _context!.Books!.Include(b => b.Title).FirstOrDefaultAsync(e => e.Id == id) ?? null;
    }

    public async Task Create(Book entity)
    {
        await _context.Books.AddAsync(entity);
    }

    public void Update(Book entity)
    {
        _context.Books.Update(entity);
    }

    public void Delete(Book entity)
    {
        _context.Books.Remove(entity);
    }
}