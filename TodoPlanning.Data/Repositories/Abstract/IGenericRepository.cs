using System.Linq.Expressions;

namespace TodoPlanning.Data.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task<bool> Any(Expression<Func<TEntity, bool>> condition);
    }
}
