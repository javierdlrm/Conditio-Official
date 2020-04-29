using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Entities
{
    public class Terms
    {
        public string Scope { get; set; }
        public int Level { get; set; }
        public IEnumerable<TermsConcept> Returns { get; set; }
        public IEnumerable<TermsConcept> Refunds { get; set; }
        public IEnumerable<TermsConcept> Guarantees { get; set; }
        public IEnumerable<TermsConcept> PaymentMethods { get; set; }
        public IEnumerable<TermsConcept> Responsibilities { get; set; }
    }

    public class TermsConcept
    {
        public string Description { get; set; }
        public int Period { get; set; }
    }
}
