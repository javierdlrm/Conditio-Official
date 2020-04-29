using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conditio.Adapter.API.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conditio.API.Controllers
{
    [Route("api/[controller]")]
    public class DomainsController : ControllerBase
    {
        private readonly IDomainServiceAdapter _domainService;

        public DomainsController(IDomainServiceAdapter domainService)
        {
            _domainService = domainService;
        }

        // GET: api/Domains/{name}
        [HttpGet("{name}")]
        public async Task<DomainDTO> GetByName(string name)
        {
            return await _domainService.GetByNameAsync(name);
        }

        // GET: api/Domains?name={name}&startWith={startWith}
        [HttpGet()]
        public async Task<IEnumerable<DomainDTO>> Filter([FromQuery] string name, [FromQuery] bool startWith = false)
        {
            return await _domainService.FilterAsync(name, startWith);
        }
    }
}