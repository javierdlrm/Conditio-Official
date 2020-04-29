using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conditio.Adapter.API.Assets;
using Conditio.Adapter.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conditio.API.Controllers
{
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetServiceAdapter _assetService;

        public AssetsController(IAssetServiceAdapter assetService)
        {
            _assetService = assetService;
        }

        // GET: api/Assets/{id}
        [HttpGet("{id}")]
        public async Task<AssetWithSourcesDTO> Get(string id)
        {
            // NOTE: Get Asset + Sources by id.
            return await _assetService.GetWithSourcesAsync(id);
        }

        // GET: api/Assets?url={url}&terms={terms}
        [HttpGet()]
        public async Task<object> GetByUrl([FromQuery] string url, [FromQuery] bool terms)
        {
            // NOTE: Get Asset + Sources by url (Default)
            //       Get Asset + Terms by url. (Terms = true)

            if (terms)
                return await _assetService.GetWithTermsByUrlAsync(url);
            else
                return await _assetService.GetWithSourcesByUrlAsync(url);
        }

        // GET: api/Assets/{id}/Source/{sourceId}
        [HttpGet("{id}/Source/{sourceId}")]
        public async Task<AssetWithTermsDTO> GetBySource(string id, string sourceId)
        {
            // NOTE: Get Asset + Terms by id and sourceId
            return await _assetService.GetWithTermsBySourceAsync(id, sourceId);
        }
    }
}