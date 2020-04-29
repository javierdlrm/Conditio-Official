using AutoMapper;
using Conditio.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Adapter.API.Domains
{
    public class DomainServiceAdapter : BaseServiceAdapter, IDomainServiceAdapter
    {
        private readonly IDomainService _domainService;

        public DomainServiceAdapter(IDomainService domainService, IMapper mapper) : base(mapper)
        {
            _domainService = domainService;
        }

        public async Task<DomainDTO> GetByNameAsync(string name)
        {
            return Mapper.Map<DomainDTO>(await _domainService.GetByNameAsync(name));
        }

        public async Task<IEnumerable<DomainDTO>> FilterAsync(string name, bool startWith)
        {
            return Mapper.Map<IEnumerable<DomainDTO>>(await _domainService.FilterAsync(name, startWith));
        }
    }
}
