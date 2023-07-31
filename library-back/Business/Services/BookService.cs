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

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Book> Search(int id)
    {
        return await _repo.Search(id);
    }

    public async Task Create(Book entity)
    {
        await _repo.Create(entity);
        await _repo.Save();
    }

    public async Task Update(Book entity)
    {
        _repo.Update(entity);
        await _repo.Save();
    }

    public async Task Delete(Book entity)
    {
        _repo.Delete(entity);
        await _repo.Save();
    }
}