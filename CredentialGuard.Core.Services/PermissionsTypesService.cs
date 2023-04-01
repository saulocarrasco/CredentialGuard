using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using CredentialGuard.Core.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Services
{
    public class PermissionsTypesService : IService<PermissionType>
    {
        private readonly IRepository<PermissionType> _repository;

        public PermissionsTypesService(IRepository<PermissionType> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> AddAsync(PermissionType entity)
        {
            var sucess = await _repository.AddAsync(entity);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(PermissionType)} was added successfully" },
                };
            }

            return new OperationResult
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            Expression<Func<PermissionType, bool>> expression = i => i.Id == id;

            var sucess = await _repository.DeleteAsync(expression);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(PermissionType)} was added successfully" },
                };
            }

            return new OperationResult
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }

        public async Task<PagedResult<PermissionType>> GetAsync(int id)
        {
            Expression<Func<PermissionType, bool>> expression = i => i.Id == id;

            var model = await _repository.GetAsync(expression);

            return new PagedResult<PermissionType>()
            {
                Data = new List<PermissionType>
                {
                    model
                },
                CurrentPage = 1,
                Totals = 1
            };
        }

        public async Task<PagedResult<PermissionType>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return new PagedResult<PermissionType>()
            {
                Data = result.ToList(),
                CurrentPage = 1,
                Totals = 1
            };
        }

        public async Task<OperationResult> UpdateAsync(int id, PermissionType entity)
        {
            Expression<Func<PermissionType, bool>> expression = i => i.Id == id;

            var currentPermissionType = await _repository.GetAsync(expression);

            currentPermissionType.Description = entity.Description;
            currentPermissionType.UpdatedAt = DateTime.UtcNow;

            var sucess = await _repository.UpdateAsync(currentPermissionType);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(PermissionType)} was added successfully" },
                };
            }

            return new OperationResult
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }
    }
}
