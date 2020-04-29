using AutoMapper;
using Conditio.Adapter.API.Entities;
using Conditio.Core.Assets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Adapter.API.Assets
{
    public class AssetServiceAdapter : BaseServiceAdapter, IAssetServiceAdapter
    {
        private readonly IAssetService _assetService;

        public AssetServiceAdapter(IAssetService assetService, IMapper mapper) : base(mapper)
        {
            _assetService = assetService;
        }

        public async Task<AssetWithSourcesDTO> GetWithSourcesAsync(string id)
        {
            return Mapper.Map<AssetWithSourcesDTO>(await _assetService.GetWithSourcesAsync(id));
        }

        public async Task<AssetWithTermsDTO> GetWithTermsByUrlAsync(string url)
        {
            return Mapper.Map<AssetWithTermsDTO>(await _assetService.GetWithTermsByUrlAsync(url));
        }

        public async Task<AssetWithSourcesDTO> GetWithSourcesByUrlAsync(string url)
        {
            return Mapper.Map<AssetWithSourcesDTO>(await _assetService.GetWithSourcesByUrlAsync(url));
        }

        public async Task<AssetWithTermsDTO> GetWithTermsBySourceAsync(string id, string sourceId)
        {
            return Mapper.Map<AssetWithTermsDTO>(await _assetService.GetWithTermsBySourceAsync(id, sourceId));
        }
    }
}
