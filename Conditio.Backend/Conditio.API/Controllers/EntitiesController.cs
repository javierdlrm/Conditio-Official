using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conditio.Adapter.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conditio.API.Controllers
{
    [Route("api/[controller]")]
    public class EntitiesController : ControllerBase
    {
        private readonly IEntityServiceAdapter _entityService;

        public EntitiesController(IEntityServiceAdapter entityService)
        {
            _entityService = entityService;
        }

        // GET: api/Entities/{id}?terms={terms}
        [HttpGet("{id}")]
        public async Task<object> Get(string id, [FromQuery] bool terms)
        {
            if (terms)
                return await _entityService.GetWithTermsAsync(id);
            else
                return await _entityService.GetAsync(id);
        }

        // GET: api/Entities?domain={domain}&terms={terms}
        [HttpGet()]
        public async Task<object> GetByDomain([FromQuery] string domain, [FromQuery] bool terms)
        {
            if (terms)
                return await _entityService.GetWithTermsByDomainAsync(domain);
            else
                return await _entityService.GetByDomainAsync(domain);
        }
    }
}