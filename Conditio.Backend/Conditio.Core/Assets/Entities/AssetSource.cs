using Conditio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Assets
{
    public class AssetSource
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public IEnumerable<string> Scopes { get; set; }
        public EntitySource Entity { get; set; }
    }
}
