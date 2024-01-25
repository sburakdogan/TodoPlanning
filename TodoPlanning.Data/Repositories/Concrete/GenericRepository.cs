using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoPlanning.Data.Repositories.Abstract;

namespace TodoPlanning.Data.Repositories.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> condition)
        {
            return await _context.Set<TEntity>().AnyAsync(condition);
        }
    }
}
