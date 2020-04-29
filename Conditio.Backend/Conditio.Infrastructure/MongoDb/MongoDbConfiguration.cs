using Conditio.Core.Assets;
using Conditio.Core.Domains;
using Conditio.Core.Entities;
using Conditio.Core.Users;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Infrastructure.MongoDb
{
    static class MongoDbConfiguration
    {
        public static void Configure()
        {
            RegisterConventions();
            RegisterBsonClassMaps();
        }

        private static void RegisterConventions()
        {
            var conventionPack = new ConventionPack();
            conventionPack.Add(new CamelCaseElementNameConvention());

            ConventionRegistry.Register("CamelCase", conventionPack, t => true);
        }

        private static void RegisterBsonClassMaps()
        {
            #region Domain

            BsonClassMap.RegisterClassMap<Domain>(cm =>
            {
                cm.AutoMap();
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(d => d.EntityId).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            #endregion

            #region Assets

            BsonClassMap.RegisterClassMap<Asset>(cm =>
            {
                cm.AutoMap();
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
            BsonClassMap.RegisterClassMap<AssetSource>(cm =>
            {
                cm.AutoMap();
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            #endregion

            #region Entities

            BsonClassMap.RegisterClassMap<EntityBase>(cm =>
            {
                cm.AutoMap();
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIsRootClass(true);
            });
            BsonClassMap.RegisterClassMap<Entity>();
            BsonClassMap.RegisterClassMap<EntitySource>();

            BsonClassMap.RegisterClassMap<Terms>(cm =>
            {
                cm.AutoMap();
            });

            #endregion

            #region Users

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            #endregion
        }
    }
}
