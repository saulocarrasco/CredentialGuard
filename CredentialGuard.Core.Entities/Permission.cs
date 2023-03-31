using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Entities
{
    public class Permission : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
