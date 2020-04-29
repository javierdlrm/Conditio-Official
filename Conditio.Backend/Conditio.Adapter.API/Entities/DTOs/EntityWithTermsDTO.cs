using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Entities
{
    public class EntityWithTermsDTO : EntityDTO
    {
        public TermsDTO Terms { get; set; }
    }
}
