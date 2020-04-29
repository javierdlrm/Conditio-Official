using Conditio.Core.Domains;
using System;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Conditio.Infrastructure.MongoDb.Queries;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Conditio.Infrastructure.MongoDb
{
    public class DomainRepository : BaseRepository<Domain>, IDomainRepository
    {
        public const string COLLECTION_NAME = "Domains";
        private readonly IMongoDbConnection _conn;

        public DomainRepository(IMongoDbConnection conn) : base(conn, COLLECTION_NAME)
        {
            _conn = conn;
        }

        public async Task<Domain> GetByNameAsync(string name)
        {
            var query = DomainQueries.GetByName(name);
            return await Collection.Aggregate<Domain>(query).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Domain>> FilterAsync(string name, bool startWith)
        {
            var query = DomainQueries.Filter(name, startWith);
            return await Collection.Aggregate<Domain>(query).ToListAsync();
        }
    }
}
