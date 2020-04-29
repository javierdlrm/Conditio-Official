using Conditio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Entities
{
    public class TermsDTO
    {
        public IEnumerable<TermsConcept> Returns { get; set; }
        public IEnumerable<TermsConcept> Refunds { get; set; }
        public IEnumerable<TermsConcept> Guarantees { get; set; }
        public IEnumerable<TermsConcept> PaymentMethods { get; set; }
        public IEnumerable<TermsConcept> Responsibilities { get; set; }
    }
}
