using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library.Business.Interfaces;

public interface IService<TEntity>
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> Search(int id);
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
}