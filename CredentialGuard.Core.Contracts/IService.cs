using CredentialGuard.Core.Shared.Dtos;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Contracts
{
    public interface IService<T> where T : class
    {
        Task<PagedResult<T>> GetAllAsync();
        Task<OperationResult<T>> AddAsync(T entity);
        Task<OperationResult<T>> UpdateAsync(int id, T entity);
        Task<PagedResult<T>> GetAsync(int id);
        Task<OperationResult<T>> DeleteAsync(int id);
    }
}
