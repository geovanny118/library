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

    public async Task<IEnumerable<Title>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Title> Search(int id)
    {
        return await _repo.Search(id);    
    }

    public async Task Create(Title entity)
    {
        await _repo.Create(entity);
        await _repo.Save();
    }

    public async Task Update(Title entity)
    {
        _repo.Update(entity);
        await _repo.Save();
    }

    public async Task Delete(Title entity)
    {
        _repo.Delete(entity);
        await _repo.Save();
    }
}