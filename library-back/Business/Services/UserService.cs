using System.Threading.Tasks;
using System.Collections.Generic;
using Library.Business.Interfaces;
using Library.Infrastructure.Models;
using Library.Infrastructure.Interfaces;

namespace Library.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task AddAsync(User entity)
    {
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        _repo.Update(entity);
        await _repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity)
    {
        _repo.Delete(entity);
        await _repo.SaveChangesAsync();
    }
}