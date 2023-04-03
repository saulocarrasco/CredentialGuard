using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> includes = null);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> includes = null);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    }
}
