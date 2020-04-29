using System;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Assets
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Task<Asset> GetWithSourcesAsync(string id);
        Task<Asset> GetWithSourcesByUrlAsync(string domain, string resource);
        Task<Asset> GetWithTermsBySourceAsync(string id, string sourceId);
        Task<Asset> GetWithTermsByUrlAsync(string domain, string resource);
    }
}
