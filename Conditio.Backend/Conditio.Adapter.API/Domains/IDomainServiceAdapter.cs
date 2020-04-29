using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Adapter.API.Domains
{
    public interface IDomainServiceAdapter
    {
        Task<DomainDTO> GetByNameAsync(string name);
        Task<IEnumerable<DomainDTO>> FilterAsync(string name, bool startWith);
    }
}
