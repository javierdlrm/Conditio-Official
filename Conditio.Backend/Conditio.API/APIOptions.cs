using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conditio.API
{
    public class APIOptions
    {
        public AppInsightsAPIOptions AppInsights { get; set; }
    }

    public class AppInsightsAPIOptions
    {
        public string InstrumentationKey { get; set; }
    }
}
