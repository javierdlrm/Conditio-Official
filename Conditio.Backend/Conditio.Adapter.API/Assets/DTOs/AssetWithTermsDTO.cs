using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Assets
{
    public class AssetWithTermsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public AssetSourceWithTermsDTO Source { get; set; }
    }
}
