using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Shared.Dtos
{
    public class OperationResult
    {
        public string[] Messages { get; set; }
        public bool IsSucesss { get; set; }
    }
}
