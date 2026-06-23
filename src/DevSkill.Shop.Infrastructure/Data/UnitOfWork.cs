using DevSkill.Shop.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Shop.Infrastructure.Data
{
    public abstract class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
