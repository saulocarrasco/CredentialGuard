using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CredentialGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IService<PermissionType> _permissionTypeService;
        public PermissionTypeController(IService<PermissionType> permissionService)
        {
            _permissionTypeService = permissionService;
        }

        // GET: api/<PermissionTypeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _permissionTypeService.GetAllAsync());
        }
    }
}
