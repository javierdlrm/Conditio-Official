using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Domains
{
    public class Domain
    {
        public string Id { get; set; }
        public string EntityId { get; set; }
        public string Name { get; set; }
        public IEnumerable<DomainSource> Assets { get; set; }
    }
}
