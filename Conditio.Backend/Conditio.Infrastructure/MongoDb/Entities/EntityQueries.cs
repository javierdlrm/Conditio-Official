using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Infrastructure.MongoDb.Queries
{
    public static class EntityQueries
    {
        const string BASE_TERMS_SCOPE = "Base";

        internal static BsonDocument[] GetWithTerms(string id)
        {
            var pipeline = new[] {
                MQB.Match(MQB.And(new BsonDocument("_id", ObjectId.Parse(id)))),
                MQB.AddFields(new BsonDocument("domsegments", MQB.Split("$domain", "'"))),
                MQB.AddFields(new BsonDocument("domain", MQB.Substr(MQB.Reduce("$domsegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                MQB.AddFields(new BsonDocument("terms", MQB.Filter("$terms", "term", MQB.And("$$term.scope", BASE_TERMS_SCOPE)))),
                MQB.AddFields(new BsonDocument("terms", MQB.ArrayElemAt("$terms", 0))),
                MQB.Project(new BsonDocument("domsegments", 0))
            };

            return pipeline;
        }

        internal static BsonDocument[] GetWithTermsByDomain(string domain)
        {
            domain = MongoDbUtils.DotsToApostrophes(domain);

            var pipeline = new[] {
                MQB.Match(MQB.And(new BsonDocument("domain", domain))),
                MQB.AddFields(new BsonDocument("domsegments", MQB.Split("$domain", "'"))),
                MQB.AddFields(new BsonDocument("domain", MQB.Substr(MQB.Reduce("$domsegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                MQB.AddFields(new BsonDocument("terms", MQB.Filter("$terms", "term", MQB.And("$$term.scope", BASE_TERMS_SCOPE)))),
                MQB.AddFields(new BsonDocument("terms", MQB.ArrayElemAt("$terms", 0))),
                MQB.Project(new BsonDocument("domsegments", 0))
            };

            return pipeline;
        }
    }
}
