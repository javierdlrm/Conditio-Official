using Conditio.Core.Assets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Assets
{
    public class AssetWithSourcesDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public IEnumerable<AssetSourceDTO> Sources { get; set; }
    }
}
