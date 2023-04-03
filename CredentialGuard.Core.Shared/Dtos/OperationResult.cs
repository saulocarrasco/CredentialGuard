using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Shared.Dtos
{
    public class OperationResult<T>
    {
        public T EntityAffect { get; set; }
        public string[] Messages { get; set; }
        public bool IsSucesss { get; set; }
    }
}
