using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using CredentialGuard.Core.Shared.Dtos;
using CredentialGuard.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Services
{
    public class PermissionsService : IService<Permission>
    {
        private readonly Repository<Permission> _repository;

        public PermissionsService(Repository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> AddAsync(Permission entity)
        {
            var sucess = await _repository.AddAsync(entity);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Permission)} was added successfully" },
                };
            }

            return new OperationResult { 
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }

        public async Task<OperationResult> DeleteAsync(Permission entity)
        {
            var sucess = await _repository.DeleteAsync(entity);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Permission)} was added successfully" },
                };
            }

            return new OperationResult
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }

        public async Task<PagedResult<Permission>> GetAsync(int id)
        {
            Expression<Func<Permission, bool>> expression = i => i.Id == id;

            var model = await _repository.GetAsync(expression);

            return new PagedResult<Permission>()
            {
                Data = new List<Permission>
                {
                    model
                },
                CurrentPage = 1,
                Totals = 1
            };
        }

        public async Task<PagedResult<Permission>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return new PagedResult<Permission>()
            {
                Data = result.ToList(),
                CurrentPage = 1,
                Totals = 1
            };
        }

        public async Task<OperationResult> UpdateAsync(Permission entity)
        {
            var sucess = await _repository.UpdateAsync(entity);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Permission)} was added successfully" },
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
