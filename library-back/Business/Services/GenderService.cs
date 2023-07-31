using Library.Business.Interfaces;
using Library.Infrastructure.Models;
using Library.Infrastructure.Interfaces;

namespace Library.Business.Services;

public class GenderService : IGenderService
{
    private readonly IGenderRepository _repo;

    public GenderService(IGenderRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Gender>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Gender> Search(int id)
    {
        return await _repo.Search(id);
    }

    public async Task Create(Gender entity)
    {
        await _repo.Create(entity);
        await _repo.Save();
    }

    public async Task Update(Gender entity)
    {
        _repo.Update(entity);
        await _repo.Save();
    }

    public async Task Delete(Gender entity)
    {
        _repo.Delete(entity);
        await _repo.Save();
    }
}