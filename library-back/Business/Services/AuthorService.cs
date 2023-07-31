using Library.Business.Interfaces;
using Library.Infrastructure.Models;
using Library.Infrastructure.Interfaces;

namespace Library.Business.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repo;

    public AuthorService(IAuthorRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Author> Search(int id)
    {
        return await _repo.Search(id);
    }

    public async Task Create(Author entity)
    {
        await _repo.Create(entity);
        await _repo.Save();
    }

    public async Task Update(Author entity)
    {
        _repo.Update(entity);
        await _repo.Save();
    }

    public async Task Delete(Author entity)
    {
        _repo.Delete(entity);
        await _repo.Save();
    }
}