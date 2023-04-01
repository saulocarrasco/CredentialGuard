using CredentialGuard.Core.Shared.Dtos;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Contracts
{
    public interface IService<T>
    {
        Task<PagedResult<T>> GetAllAsync();
        Task<OperationResult> AddAsync(T entity);
        Task<OperationResult> UpdateAsync(T entity);
        Task<PagedResult<T>> GetAsync(int id);
        Task<OperationResult> DeleteAsync(T entity);
    }
}
