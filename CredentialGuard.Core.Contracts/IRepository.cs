using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<bool> Delete(T entity);
    }
}
