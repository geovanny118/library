using System.Threading.Tasks;
using System.Collections.Generic;
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

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Author> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task AddAsync(Author entity)
    {
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Author entity)
    {
        _repo.Update(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(Author entity)
    {
        _repo.Delete(entity);
        await _repo.SaveChangesAsync();
    }
}