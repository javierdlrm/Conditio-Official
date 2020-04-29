using System;
using System.Collections.Generic;
using System.Text;
using Conditio.Core.Assets;
using Conditio.Core.Domains;
using Conditio.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Conditio.Infrastructure.MongoDb.Queries
{
    public static class DomainQueries
    {
        internal static BsonDocument[] GetByName(string name)
        {
            name = MongoDbUtils.DotsToApostrophes(name.ToLower());

            var pipeline = new[] {
                MQB.Match(MQB.And(new BsonDocument("name", name))),
                MQB.AddFields(new BsonDocument("namesegments", MQB.Split("$name", "'"))),
                MQB.AddFields(new BsonDocument("name", MQB.Substr(MQB.Reduce("$namesegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                MQB.Project(new BsonDocument("_id", 0).Add("assets", 0).Add("namesegments", 0))
            };

            return pipeline;
        }

        internal static BsonDocument[] Filter(string name, bool startWith)
        {
            name = MongoDbUtils.DotsToApostrophes(name.ToLower());
            string pattern = startWith ? $"/^{name}/" : $"/.*{name}.*/";

            var pipeline = new[]
            {
                MQB.Match(MQB.And(new BsonDocument("name", new BsonRegularExpression(pattern)))),
                MQB.AddFields(new BsonDocument("namesegments", MQB.Split("$name", "'"))),
                MQB.AddFields(new BsonDocument("name", MQB.Substr(MQB.Reduce("$namesegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                MQB.Project(new BsonDocument("_id", 0).Add("assets", 0).Add("namesegments", 0))
            };

            return pipeline;
        }
    }
}
