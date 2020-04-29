using Conditio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Assets
{
    public interface IAssetService
    {
        Task<Asset> GetWithSourcesAsync(string id);
        Task<Asset> GetWithSourcesByUrlAsync(string url);
        Task<Asset> GetWithTermsBySourceAsync(string id, string sourceId);
        Task<Asset> GetWithTermsByUrlAsync(string url);
    }
}
