using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CredentialGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IService<Permission> _permissionService;
        private readonly IService<Employee> _employeeService;
        public PermissionController(IService<Permission> permissionService, IService<Employee> employeeService)
        {
            _permissionService = permissionService;
            _employeeService = employeeService;
        }
        // GET: api/<PermissionController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _permissionService.GetAllAsync());
        }

        // GET api/<PermissionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _permissionService.GetAsync(id));
        }

        // POST api/<PermissionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Permission permission)
        {
            var addEmployeeResult = await _employeeService.AddAsync(permission.Employee);
            permission.EmployeeId = addEmployeeResult.EntityAffect.Id;
            var addResult = await _permissionService.AddAsync(permission);

            return CreatedAtAction(nameof(Post), addResult);
        }

        // PUT api/<PermissionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Permission permission)
        {
            var updateResult = await _permissionService.UpdateAsync(id, permission);

            return Ok(updateResult);
        }

        // DELETE api/<PermissionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteResult = await _permissionService.DeleteAsync(id);

            return Ok(deleteResult);
        }
    }
}
