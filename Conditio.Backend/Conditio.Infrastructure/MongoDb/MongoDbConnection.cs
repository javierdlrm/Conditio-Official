using Conditio.Core.Entities;
using Conditio.Core.Users;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Infrastructure.MongoDb
{
    public interface IMongoDbConnection
    {
        IMongoDatabase Database { get; }
    }

    public class MongoDbConnection : IMongoDbConnection
    {
        public IMongoDatabase Database { get; private set; }

        private readonly IMongoClient _client;

        public MongoDbConnection(MongoDbOptions settings)
        {
            MongoDbConfiguration.Configure();

            _client = new MongoClient(settings.ConnectionString);
            Database = _client.GetDatabase(settings.Database);
        }
    }
}
