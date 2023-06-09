﻿using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using CredentialGuard.Core.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Services
{
    public class PermissionsService : IService<Permission>
    {
        private readonly IRepository<Permission> _repository;

        public PermissionsService(IRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<Permission>> AddAsync(Permission entity)
        {
            var sucess = await _repository.AddAsync(entity);

            if (sucess)
            {
                return new OperationResult<Permission>
                {
                    EntityAffect = entity,
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Permission)} was added successfully" },
                };
            }

            return new OperationResult<Permission>
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }

        public async Task<OperationResult<Permission>> DeleteAsync(int id)
        {
            Expression<Func<Permission, bool>> expression = i => i.Id == id;

            var sucess = await _repository.DeleteAsync(expression);

            if (sucess)
            {
                return new OperationResult<Permission>
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Permission)} was deleted successfully" },
                };
            }

            return new OperationResult<Permission>
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }

        public async Task<PagedResult<Permission>> GetAsync(int id)
        {
            Expression<Func<Permission, bool>> expression = i => i.Id == id && i.Active == true;
            Expression<Func<Permission, object>> includes = i => i.Employee;

            var model = await _repository.GetAsync(expression, includes);

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
            Expression<Func<Permission, object>> includes = i => i.Employee;

            var result = await _repository.GetAllAsync(includes);

            return new PagedResult<Permission>()
            {
                Data = result.ToList(),
                CurrentPage = 1,
                Totals = 1
            };
        }

        public async Task<OperationResult<Permission>> UpdateAsync(int id, Permission entity)
        {
            Expression<Func<Permission, bool>> expression = i => i.Id == id;

            var currentPermission = await _repository.GetAsync(expression);

            currentPermission.PermissionTypeId = entity.PermissionTypeId;
            currentPermission.UpdatedAt = DateTime.UtcNow;

            var sucess = await _repository.UpdateAsync(currentPermission);

            if (sucess)
            {
                return new OperationResult<Permission>
                {
                    EntityAffect = currentPermission,
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Permission)} was update successfully" },
                };
            }

            return new OperationResult<Permission>
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }
    }
}
