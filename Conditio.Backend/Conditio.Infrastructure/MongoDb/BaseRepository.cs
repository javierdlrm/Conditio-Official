using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Infrastructure.MongoDb
{
    public class BaseRepository<TDocument> where TDocument : class
    {
        public IMongoCollection<TDocument> Collection { get; }

        public BaseRepository(IMongoDbConnection conn, string collectionName)
        {
            Collection = conn.Database.GetCollection<TDocument>(collectionName);
        }

        #region CRUD

        public async Task AddAsync(TDocument document)
        {
            await Collection.InsertOneAsync(document);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq("id", ObjectId.Parse(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<TDocument> GetAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            await Collection.ReplaceOneAsync(filter, document);
        }

        #endregion
    }
}
