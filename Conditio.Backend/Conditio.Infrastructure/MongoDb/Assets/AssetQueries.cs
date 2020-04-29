using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Infrastructure.MongoDb.Queries
{
    public static class AssetQueries
    {
        internal static BsonDocument[] GetWithSources(string id)
        {
            var pipeline = new[] {
                MQB.Match(MQB.And(new BsonDocument("_id", ObjectId.Parse(id)))),
                MQB.Project(new BsonDocument("sources._id", 0)),
                MQB.Unwind("$sources"),
                MQB.Lookup(EntityRepository.COLLECTION_NAME, new BsonDocument("domain", "$sources.domain"), new []
                {
                    MQB.Match(MQB.Expr(MQB.Eq("$domain", "$$domain"))),
                    MQB.AddFields(new BsonDocument("domsegments", MQB.Split("$domain", "'"))),
                    MQB.AddFields(new BsonDocument("domain", MQB.Substr(MQB.Reduce("$domsegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                    MQB.Project(new BsonDocument("terms", 0).Add("domsegments", 0))
                }, "entity"),
                MQB.AddFields(new BsonDocument("sources.entity", MQB.ArrayElemAt("$entity", 0))),
                MQB.Project(new BsonDocument("sources._id", 0).Add("sources.domain", 0)),
                MQB.Group("$_id", ("data", new BsonDocument("$first", "$$ROOT")), ("sources", new BsonDocument("$addToSet", "$sources"))),
                MQB.Project(new BsonDocument("data.sources", 0).Add("data.entity", 0)),
                MQB.ReplaceRoot(MQB.Merge("$data", "$$ROOT")),
                MQB.Project(new BsonDocument("data", 0))
            };

            return pipeline;
        }

        internal static BsonDocument[] GetWithTermsByUrl(string domain, string resource)
        {
            domain = MongoDbUtils.DotsToApostrophes(domain);

            var pipeline = new[] {
                MQB.Match(MQB.And(new BsonDocument("name", domain), new BsonDocument("assets", MQB.ElemMatch(new BsonDocument("url", resource))))),
                MQB.Project(new BsonDocument("entityId", 1).Add("asset", MQB.ArrayElemAt(MQB.Filter("$assets", "asset", MQB.Eq("$$asset.url", resource)), 0))),
                MQB.Lookup(AssetRepository.COLLECTION_NAME, new BsonDocument("assetId", "$asset.assetId").Add("sourceId", "$asset.sourceId"), new [] {
                    MQB.Match(MQB.Expr(MQB.And(
                            MQB.Eq("$_id", "$$assetId"),
                            MQB.Filter("$sources", "source", MQB.Eq("$$source._id", "$$sourceId"))))),
                    MQB.AddFields(new BsonDocument("source", MQB.ArrayElemAt("$sources", 0))),
                    MQB.Project(new BsonDocument("sources", 0).Add("source.domain", 0))
                }, "asset"),
                MQB.ReplaceRoot(MQB.Merge("$$ROOT", MQB.ArrayElemAt("$asset", 0))),
                MQB.Project(new BsonDocument("asset", 0)),
                MQB.Lookup(EntityRepository.COLLECTION_NAME, new BsonDocument("entityId", "$entityId").Add("scopes", "$source.scopes"), new []
                {
                    MQB.Match(MQB.Expr(MQB.Eq("$_id", "$$entityId"))),
                    MQB.AddFields(new BsonDocument("domsegments", MQB.Split("$domain", "'"))),
                    MQB.AddFields(new BsonDocument("domain", MQB.Substr(MQB.Reduce("$domsegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                    MQB.Project(new BsonDocument("domsegments", 0)),
                    MQB.AddFields(new BsonDocument("terms", MQB.Filter("$terms", "term", MQB.In("$$term.scope", "$$scopes")))),
                    MQB.AddFields(new BsonDocument("terms", MQB.Reduce("$terms", new BsonDocument("returns", new BsonArray()).Add("refunds", new BsonArray()).Add("guarantees", new BsonArray()).Add("paymentMethods", new BsonArray()).Add("responsibilities", new BsonArray()),
                            new BsonDocument("returns", MQB.ConcatArrays("$$value.returns", MQB.IfNull("$$this.returns", new BsonArray())))
                            .Add("refunds", MQB.ConcatArrays("$$value.refunds", MQB.IfNull("$$this.refunds", new BsonArray())))
                            .Add("guarantees", MQB.ConcatArrays("$$value.guarantees", MQB.IfNull("$$this.guarantees", new BsonArray())))
                            .Add("paymentMethods", MQB.ConcatArrays("$$value.paymentMethods", MQB.IfNull("$$this.paymentMethods", new BsonArray())))
                            .Add("responsibilities", MQB.ConcatArrays("$$value.responsibilities", MQB.IfNull("$$this.responsibilities", new BsonArray())))))),
                    MQB.AddFields(
                        new BsonDocument("terms.returns", MQB.Reduce(MQB.ReverseArray("$terms.returns"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.refunds", MQB.Reduce(MQB.ReverseArray("$terms.refunds"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.guarantees", MQB.Reduce(MQB.ReverseArray("$terms.guarantees"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.paymentMethods", MQB.Reduce(MQB.ReverseArray("$terms.paymentMethods"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.responsibilities", MQB.Reduce(MQB.ReverseArray("$terms.responsibilities"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" })))))
                }, "entity"),
                MQB.AddFields(new BsonDocument("source.entity", MQB.ArrayElemAt("$entity", 0))),
                MQB.AddFields(new BsonDocument("sources", new BsonArray { "$source" })),
                MQB.Project(new BsonDocument("entityId", 0).Add("entity", 0).Add("source", 0))
            };

            return pipeline;
        }

        internal static BsonDocument[] GetWithSourcesByUrl(string domain, string url)
        {
            domain = MongoDbUtils.DotsToApostrophes(domain);

            var pipeline = new[] {
                MQB.Match(MQB.And(new BsonDocument("name", domain), new BsonDocument("assets", MQB.ElemMatch(new BsonDocument("url", url))))),
                MQB.Project(new BsonDocument("asset", MQB.ArrayElemAt(MQB.Filter("$assets", "asset", MQB.Eq("$$asset.url", url)), 0))),
                MQB.Lookup(AssetRepository.COLLECTION_NAME, new BsonDocument("assetId", "$asset.assetId"), new [] {
                    MQB.Match(MQB.Expr(MQB.Eq("$_id", "$$assetId")))
                }, "asset"),
                MQB.ReplaceRoot(MQB.Merge("$$ROOT", MQB.ArrayElemAt("$asset", 0))),
                MQB.Project(new BsonDocument("asset", 0)),
                MQB.Unwind("$sources"),
                MQB.Lookup(EntityRepository.COLLECTION_NAME, new BsonDocument("domain", "$sources.domain"), new []
                {
                    MQB.Match(MQB.Expr(MQB.Eq("$domain", "$$domain"))),
                    MQB.AddFields(new BsonDocument("domsegments", MQB.Split("$domain", "'"))),
                    MQB.AddFields(new BsonDocument("domain", MQB.Substr(MQB.Reduce("$domsegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                    MQB.Project(new BsonDocument("terms", 0).Add("domsegments", 0))
                }, "entity"),
                MQB.AddFields(new BsonDocument("sources.entity", MQB.ArrayElemAt("$entity", 0))),
                MQB.Project(new BsonDocument("sources._id", 0).Add("sources.domain", 0)),
                MQB.Group("$_id", ("data", new BsonDocument("$first", "$$ROOT")), ("sources", new BsonDocument("$addToSet", "$sources"))),
                MQB.Project(new BsonDocument("data.sources", 0).Add("data.entity", 0)),
                MQB.ReplaceRoot(MQB.Merge("$data", "$$ROOT")),
                MQB.Project(new BsonDocument("data", 0))
            };

            return pipeline;
        }

        internal static BsonDocument[] GetWithTermsBySource(string id, string sourceId)
        {
            var pipeline = new[] {
                MQB.Match(MQB.And(new BsonDocument("_id", ObjectId.Parse(id)), new BsonDocument("sources", MQB.ElemMatch(new BsonDocument("_id", ObjectId.Parse(sourceId)))))),
                MQB.AddFields(new BsonDocument("source", MQB.ArrayElemAt(MQB.Filter("$sources", "source", MQB.Eq("$$source._id", ObjectId.Parse(sourceId))), 0))),
                MQB.Project(new BsonDocument("sources", 0).Add("source._id", 0)),
                MQB.Lookup(EntityRepository.COLLECTION_NAME, new BsonDocument("domain", "$source.domain").Add("scopes", "$source.scopes"), new []
                {
                    MQB.Match(MQB.Expr(MQB.Eq("$domain", "$$domain"))),
                    MQB.AddFields(new BsonDocument("domsegments", MQB.Split("$domain", "'"))),
                    MQB.AddFields(new BsonDocument("domain", MQB.Substr(MQB.Reduce("$domsegments", "", MQB.Concat("$$value", ".", "$$this")), 1, -1))),
                    MQB.Project(new BsonDocument("domsegments", 0)),
                    MQB.AddFields(new BsonDocument("terms", MQB.Filter("$terms", "term", MQB.In("$$term.scope", "$$scopes")))),
                    MQB.AddFields(new BsonDocument("terms", MQB.Reduce("$terms", new BsonDocument("returns", new BsonArray()).Add("refunds", new BsonArray()).Add("guarantees", new BsonArray()),
                            new BsonDocument("returns", MQB.ConcatArrays("$$value.returns", MQB.IfNull("$$this.returns", new BsonArray())))
                            .Add("refunds", MQB.ConcatArrays("$$value.refunds", MQB.IfNull("$$this.refunds", new BsonArray())))
                            .Add("guarantees", MQB.ConcatArrays("$$value.guarantees", MQB.IfNull("$$this.guarantees", new BsonArray())))
                            .Add("paymentMethods", MQB.ConcatArrays("$$value.paymentMethods", MQB.IfNull("$$this.paymentMethods", new BsonArray())))
                            .Add("responsibilities", MQB.ConcatArrays("$$value.responsibilities", MQB.IfNull("$$this.responsibilities", new BsonArray())))))),
                    MQB.AddFields(
                        new BsonDocument("terms.returns", MQB.Reduce(MQB.ReverseArray("$terms.returns"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.refunds", MQB.Reduce(MQB.ReverseArray("$terms.refunds"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.guarantees", MQB.Reduce(MQB.ReverseArray("$terms.guarantees"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.paymentMethods", MQB.Reduce(MQB.ReverseArray("$terms.paymentMethods"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" }))))
                        .Add("terms.responsibilities", MQB.Reduce(MQB.ReverseArray("$terms.responsibilities"), new BsonArray(),
                            MQB.ConcatArrays("$$value",
                                MQB.Cond(MQB.Ne(MQB.Size(MQB.Filter("$$value", "v", MQB.Eq("$$v.concept", "$$this.concept"))), 0), new BsonArray(), new BsonArray { "$$this" })))))
                }, "entity"),
                MQB.AddFields(new BsonDocument("source.entity", MQB.ArrayElemAt("$entity", 0))),
                MQB.AddFields(new BsonDocument("sources", new BsonArray { "$source" })),
                MQB.Project(new BsonDocument("entityId", 0).Add("entity", 0).Add("source", 0).Add("sources.domain", 0))
            };

            return pipeline;
        }
    }
}
