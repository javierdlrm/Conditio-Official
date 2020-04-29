using Conditio.Core.Entities;
using Conditio.Infrastructure.MongoDb.Queries;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Infrastructure.MongoDb
{
    public class EntityRepository : BaseRepository<Entity>, IEntityRepository
    {
        public const string COLLECTION_NAME = "Entities";

        public EntityRepository(IMongoDbConnection conn) : base(conn, COLLECTION_NAME)
        {
        }

        public new async Task<Entity> GetAsync(string id)
        {
            var filter = Builders<Entity>.Filter.Eq("_id", ObjectId.Parse(id));
            var projection = Builders<Entity>.Projection.Exclude(e => e.Terms);
            var entity = await Collection.Find(filter).Project<Entity>(projection).FirstOrDefaultAsync();

            entity.Domain = MongoDbUtils.ApostrophesToDots(entity.Domain);
            return entity;
        }

        public async Task<EntitySource> GetWithTermsAsync(string id)
        {
            var query = EntityQueries.GetWithTerms(id);
            return await Collection.Aggregate<EntitySource>(query).FirstOrDefaultAsync();
        }

        public async Task<Entity> GetByDomainAsync(string domain)
        {
            domain = MongoDbUtils.DotsToApostrophes(domain);
            var filter = Builders<Entity>.Filter.Eq(e => e.Domain, domain);
            var projection = Builders<Entity>.Projection.Exclude(e => e.Terms);
            var entity = await Collection.Find(filter).Project<Entity>(projection).FirstAsync();

            entity.Domain = MongoDbUtils.ApostrophesToDots(entity.Domain);
            return entity;
        }

        public async Task<EntitySource> GetWithTermsByDomainAsync(string domain)
        {
            var query = EntityQueries.GetWithTermsByDomain(domain);
            return await Collection.Aggregate<EntitySource>(query).FirstOrDefaultAsync();
        }
    }
}
