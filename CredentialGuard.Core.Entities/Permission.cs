﻿

namespace CredentialGuard.Core.Entities
{
    public class Permission : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
