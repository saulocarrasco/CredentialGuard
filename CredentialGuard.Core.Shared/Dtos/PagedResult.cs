using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialGuard.Core.Shared.Dtos
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            Data = new List<T>();
        }
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int Totals { get; set; }
    }
}
