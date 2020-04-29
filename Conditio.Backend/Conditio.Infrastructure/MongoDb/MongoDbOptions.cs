using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Infrastructure.MongoDb
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
