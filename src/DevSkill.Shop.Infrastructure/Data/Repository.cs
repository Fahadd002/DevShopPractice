using DevSkill.Shop.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Shop.Infrastructure.Data
{
    public abstract class Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>, IDisposable
        where TAggregateRoot : class, IAggregateRoot<TKey> where TKey : IComparable
    {
        private DbContext _dbContext;
        private DbSet<TAggregateRoot> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TAggregateRoot>();
        }

        public void Add(TAggregateRoot entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TAggregateRoot entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IList<TAggregateRoot> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IList<TAggregateRoot>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
