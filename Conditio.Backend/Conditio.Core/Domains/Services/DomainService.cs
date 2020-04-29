using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Domains
{
    public class DomainService : IDomainService
    {
        private readonly IDomainRepository _domainRepository;

        public DomainService(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public async Task<IEnumerable<Domain>> FilterAsync(string name, bool startWith)
        {
            return await _domainRepository.FilterAsync(name, startWith);
        }

        public async Task<Domain> GetByNameAsync(string name)
        {
            return await _domainRepository.GetByNameAsync(name);
        }
    }
}
