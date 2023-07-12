using Library.Business.Interfaces;
using Library.Infrastructure.Models;
using Library.Infrastructure.Interfaces;

namespace Library.Business.Services;

public class TitleService : ITitleService 
{
    private readonly ITitleRepository _repo;

    public TitleService(ITitleRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Title>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Title> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);    
    }

    public async Task AddAsync(Title entity)
    {
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Title entity)
    {
        _repo.Update(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(Title entity)
    {
        _repo.Delete(entity);
        await _repo.SaveChangesAsync();
    }
}