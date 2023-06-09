﻿using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly CredentialGuardDbContext _dbContext;
        public Repository(CredentialGuardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(T entity)
        {
            entity.Active = true;
            _dbContext.Set<T>().Add(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var currentEntity = await _dbContext.Set<T>().FirstOrDefaultAsync(expression);

            currentEntity.Active = false;

            _dbContext.Entry(currentEntity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> includes)
        {
            if (includes != null)
            {
                return await _dbContext.Set<T>().Include(includes).FirstOrDefaultAsync(expression);
            }
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> includes)
        {
            if (includes != null)
            {
                return await _dbContext.Set<T>().Include(includes).Where(i=>i.Active == true).ToListAsync();
            }
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
