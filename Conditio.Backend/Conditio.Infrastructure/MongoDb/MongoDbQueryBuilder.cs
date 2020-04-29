using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Infrastructure.MongoDb
{
    internal static class MQB
    {
        internal static BsonDocument Expr(BsonDocument value) => new BsonDocument("$expr", value);
        internal static BsonDocument And(params BsonValue[] values) => new BsonDocument("$and", new BsonArray(values));
        internal static BsonDocument Eq(params BsonValue[] values) => new BsonDocument("$eq", new BsonArray(values));
        internal static BsonDocument Ne(params BsonValue[] values) => new BsonDocument("$ne", new BsonArray(values));
        internal static BsonDocument IfNull(params BsonValue[] values) => new BsonDocument("$ifNull", new BsonArray(values));
        internal static BsonDocument In(params BsonValue[] values) => new BsonDocument("$in", new BsonArray(values));
        internal static BsonDocument Substr(params BsonValue[] values) => new BsonDocument("$substr", new BsonArray(values));
        internal static BsonDocument Cond(BsonValue @if, BsonValue then, BsonValue @else)
            => new BsonDocument("$cond", new BsonDocument("if", @if).Add("then", then).Add("else", @else));

        internal static BsonDocument ElemMatch(BsonDocument value) => new BsonDocument("$elemMatch", value);
        internal static BsonDocument ArrayElemAt(params BsonValue[] values) => new BsonDocument("$arrayElemAt", new BsonArray(values));
        internal static BsonDocument ConcatArrays(params BsonValue[] values) => new BsonDocument("$concatArrays", new BsonArray(values));
        internal static BsonDocument ReverseArray(BsonValue value) => new BsonDocument("$reverseArray", value);
        internal static BsonDocument Size(BsonValue value) => new BsonDocument("$size", value);
        internal static BsonDocument Split(params BsonValue[] values) => new BsonDocument("$split", new BsonArray(values));
        internal static BsonDocument Concat(params BsonValue[] values) => new BsonDocument("$concat", new BsonArray(values));

        internal static BsonDocument Unwind(string path) => new BsonDocument("$unwind", path);
        internal static BsonDocument Match(BsonDocument value) => new BsonDocument("$match", value);
        internal static BsonDocument AddFields(BsonDocument value) => new BsonDocument("$addFields", value);
        internal static BsonDocument Project(BsonDocument value) => new BsonDocument("$project", value);
        internal static BsonDocument Merge(params BsonValue[] values) => new BsonDocument("$mergeObjects", new BsonArray(values));
        internal static BsonDocument ReplaceRoot(BsonDocument newRoot) => new BsonDocument("$replaceRoot", new BsonDocument("newRoot", newRoot));
        internal static BsonDocument Filter(BsonValue input, BsonValue @as, BsonDocument cond)
            => new BsonDocument("$filter", new BsonDocument("input", input).Add("as", @as).Add("cond", cond));
        internal static BsonDocument Reduce(BsonValue input, BsonValue initialValue, BsonDocument @in)
            => new BsonDocument("$reduce", new BsonDocument("input", input).Add("initialValue", initialValue).Add("in", @in));
        internal static BsonDocument Lookup(string collection, BsonValue let, BsonDocument[] pipeline, string @as)
            => new BsonDocument("$lookup", new BsonDocument("from", collection).Add("let", let).Add("pipeline", new BsonArray(pipeline)).Add("as", @as));
        internal static BsonDocument Group(string id, params (string, BsonDocument)[] values)
        {
            var doc = new BsonDocument("_id", id);
            foreach (var d in values) doc.Add(d.Item1, d.Item2);
            return new BsonDocument("$group", doc);
        }
    }
}
