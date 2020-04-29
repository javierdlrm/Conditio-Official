using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Entities
{
    public class EntityBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Category { get; set; }
    }
}
