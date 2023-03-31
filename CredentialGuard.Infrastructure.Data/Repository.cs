using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
