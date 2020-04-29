using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conditio.Core.Domains;
using Conditio.Core.Entities;

namespace Conditio.Core.Assets
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        
        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<Asset> GetWithSourcesAsync(string id)
        {
            return await _assetRepository.GetWithSourcesAsync(id);
        }

        public async Task<Asset> GetWithSourcesByUrlAsync(string url)
        {
            var slash = url.IndexOf("/");
            var domain = url.Substring(0, slash);
            var resource = url.Substring(slash);

            return await _assetRepository.GetWithSourcesByUrlAsync(domain, resource);
        }

        public async Task<Asset> GetWithTermsBySourceAsync(string id, string sourceId)
        {
            return await _assetRepository.GetWithTermsBySourceAsync(id, sourceId);
        }

        public async Task<Asset> GetWithTermsByUrlAsync(string url)
        {
            var slash = url.IndexOf("/");
            var domain = url.Substring(0, slash);
            var resource = url.Substring(slash);

            return await _assetRepository.GetWithTermsByUrlAsync(domain, resource);
        }
    }
}
