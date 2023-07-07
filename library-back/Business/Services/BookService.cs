using System.Threading.Tasks;
using System.Collections.Generic;
using Library.Business.Interfaces;
using Library.Infrastructure.Models;
using Library.Infrastructure.Interfaces;

namespace Library.Business.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repo;

    public BookService(IBookRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task AddAsync(Book entity)
    {
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book entity)
    {
        _repo.Update(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book entity)
    {
        _repo.Delete(entity);
        await _repo.SaveChangesAsync();
    }
}