using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Entities
{
    public class Entity : EntityBase
    {
        public IEnumerable<Terms> Terms { get; set; }
    }
}
