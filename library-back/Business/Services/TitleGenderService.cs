using Library.Business.Interfaces;
using Library.Infrastructure.Models;
using Library.Infrastructure.Interfaces;

namespace Library.Business.Services;

public class TitleGenderService : ITitleGenderService
{
    private readonly ITitlesGenderRepository _repo;

    public TitleGenderService(ITitlesGenderRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<IEnumerable<TitlesGender>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<TitlesGender> Search(int id)
    {
        return await _repo.Search(id);
    }

    public async Task Create(TitlesGender entity)
    {
        await _repo.Create(entity);
        await _repo.Save();
    }

    public async Task Update(TitlesGender entity)
    {
        _repo.Update(entity);
        await _repo.Save();
    }

    public async Task Delete(TitlesGender entity)
    {
        _repo.Delete(entity);
        await _repo.Save();
    }
}