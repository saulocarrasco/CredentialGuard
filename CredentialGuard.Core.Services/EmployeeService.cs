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
    public class EmployeeService : IService<Employee>
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> AddAsync(Employee entity)
        {
            var sucess = await _repository.AddAsync(entity);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Employee)} was added successfully" },
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
            Expression<Func<Employee, bool>> expression = i => i.Id == id;

            var sucess = await _repository.DeleteAsync(expression);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Employee)} was added successfully" },
                };
            }

            return new OperationResult
            {
                IsSucesss = false,
                Messages = new string[] { "Operation Fail" },
            };
        }

        public async Task<PagedResult<Employee>> GetAsync(int id)
        {
            Expression<Func<Employee, bool>> expression = i => i.Id == id;

            var model = await _repository.GetAsync(expression);

            return new PagedResult<Employee>()
            {
                Data = new List<Employee>
                {
                    model
                },
                CurrentPage = 1,
                Totals = 1
            };
        }

        public async Task<PagedResult<Employee>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return new PagedResult<Employee>()
            {
                Data = result.ToList(),
                CurrentPage = 1,
                Totals = 1
            };
        }

        public async Task<OperationResult> UpdateAsync(int id, Employee entity)
        {
            Expression<Func<Employee, bool>> expression = i => i.Id == id;

            var currentEmployee = await _repository.GetAsync(expression);

            currentEmployee.Name = entity.Name;
            currentEmployee.LastName = entity.LastName;
            currentEmployee.UpdatedAt = DateTime.UtcNow;

            var sucess = await _repository.UpdateAsync(currentEmployee);

            if (sucess)
            {
                return new OperationResult
                {
                    IsSucesss = true,
                    Messages = new string[] { $"{nameof(Employee)} was added successfully" },
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
