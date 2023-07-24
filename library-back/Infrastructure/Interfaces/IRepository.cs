namespace Library.Infrastructure.Interfaces;

public interface IRepository<TEntity>
{
    public Task Save();
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity> Search(int id);
    public Task Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
}