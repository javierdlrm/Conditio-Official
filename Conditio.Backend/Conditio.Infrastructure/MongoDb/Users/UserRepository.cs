using Conditio.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Conditio.Infrastructure.MongoDb
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public const string COLLECTION_NAME = "Users";

        public UserRepository(IMongoDbConnection conn) : base(conn, COLLECTION_NAME)
        {
        }

        public async Task UpdateAsync(string id, UserUpdate item)
        {
            var filter = Builders<User>.Filter.Eq("id", ObjectId.Parse(id));
            var update = Builders<User>.Update
                .Set(u => u.Profile, item)
                .Set(u => u.Account.Hidden, item.Hidden);

            await Collection.UpdateOneAsync(filter, update);
        }

        public async Task<Credentials> GetCredentialsByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq("account.credentials.email", email);
            var projection = Builders<User>.Projection.Include(u => u.Account.Credentials);
            return await Collection.Find(filter).Project<Credentials>(projection).FirstAsync();
        }
    }
}
