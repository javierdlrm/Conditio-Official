using Conditio.Core.Assets;
using Conditio.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Conditio.Infrastructure.MongoDb.Queries;

namespace Conditio.Infrastructure.MongoDb
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        public const string COLLECTION_NAME = "Assets";
        private readonly IMongoDbConnection _conn;

        public AssetRepository(IMongoDbConnection conn) : base(conn, COLLECTION_NAME)
        {
            _conn = conn;
        }

        public async Task<Asset> GetWithSourcesAsync(string id)
        {
            var query = AssetQueries.GetWithSources(id);
            return await Collection.Aggregate<Asset>(query).FirstOrDefaultAsync();
        }

        public async Task<Asset> GetWithTermsBySourceAsync(string id, string sourceId)
        {
            var query = AssetQueries.GetWithTermsBySource(id, sourceId);
            return await Collection.Aggregate<Asset>(query).FirstOrDefaultAsync();
        }

        public async Task<Asset> GetWithTermsByUrlAsync(string domain, string resource)
        {
            var domains = _conn.Database.GetCollection<Core.Domains.Domain>(DomainRepository.COLLECTION_NAME);

            var query = AssetQueries.GetWithTermsByUrl(domain, resource);
            return await domains.Aggregate<Asset>(query).FirstOrDefaultAsync();
        }

        public async Task<Asset> GetWithSourcesByUrlAsync(string domain, string resource)
        {
            var domains = _conn.Database.GetCollection<Core.Domains.Domain>(DomainRepository.COLLECTION_NAME);

            var query = AssetQueries.GetWithSourcesByUrl(domain, resource);
            return await domains.Aggregate<Asset>(query).FirstOrDefaultAsync();
        }
    }
}
