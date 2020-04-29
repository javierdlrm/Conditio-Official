using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Domains
{
    public interface IDomainService
    {
        Task<Domain> GetByNameAsync(string name);
        Task<IEnumerable<Domain>> FilterAsync(string name, bool startWith);
    }
}
