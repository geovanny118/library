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

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<User> Search(int id)
    {
        return await _repo.Search(id);
    }

    public async Task Create(User entity)
    {
        await _repo.Create(entity);
        await _repo.Save();
    }

    public async Task Update(User entity)
    {
        _repo.Update(entity);
        await _repo.Save();
    }

    public async Task Delete(User entity)
    {
        _repo.Delete(entity);
        await _repo.Save();
    }
}