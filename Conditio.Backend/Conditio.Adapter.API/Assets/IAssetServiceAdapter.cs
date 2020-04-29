using Conditio.Adapter.API.Entities;
using Conditio.Core.Assets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Adapter.API.Assets
{
    public interface IAssetServiceAdapter
    {
        Task<AssetWithSourcesDTO> GetWithSourcesAsync(string id);
        Task<AssetWithSourcesDTO> GetWithSourcesByUrlAsync(string url);

        Task<AssetWithTermsDTO> GetWithTermsByUrlAsync(string url);
        Task<AssetWithTermsDTO> GetWithTermsBySourceAsync(string id, string sourceId);
    }
}
