using Library.Business.Interfaces;
using Library.Infrastructure.Models;
using Library.Infrastructure.Interfaces;

namespace Library.Business.Services;

public class AuthorTitleService : IAuthorTitleService
{
    private readonly IAuthorTitleRepository _repo;

    public AuthorTitleService(IAuthorTitleRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<AuthorsTitle>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<AuthorsTitle> Search(int id)
    {
        return await _repo.Search(id);
    }

    public async Task Create(AuthorsTitle entity)
    {
        await _repo.Create(entity);
        await _repo.Save();
    }

    public async Task Update(AuthorsTitle entity)
    {
        _repo.Update(entity);
        await _repo.Save();
    }

    public async Task Delete(AuthorsTitle entity)
    {
        _repo.Delete(entity);
        await _repo.Save();
    }
}