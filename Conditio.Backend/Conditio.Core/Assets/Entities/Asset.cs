using Conditio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Assets
{
    public class Asset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public IEnumerable<AssetSource> Sources { get; set; }
    }
}
