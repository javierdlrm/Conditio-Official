using Conditio.Adapter.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Assets
{
    public class AssetSourceWithTermsDTO
    {
        public string Url { get; set; }
        public IEnumerable<string> Scopes { get; set; }
        public EntityWithTermsDTO Entity { get; set; }
    }
}
