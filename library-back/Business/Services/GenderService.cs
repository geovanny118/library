using System.Threading.Tasks;
using System.Collections.Generic;
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

    public async Task<IEnumerable<Gender>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Gender> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task AddAsync(Gender entity)
    {
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Gender entity)
    {
        _repo.Update(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(Gender entity)
    {
        _repo.Delete(entity);
        await _repo.SaveChangesAsync();
    }
}