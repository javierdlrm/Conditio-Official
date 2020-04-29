using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Infrastructure.MongoDb
{
    public static class MongoDbUtils
    {
        public static string ApostrophesToDots(string text)
        {
            return text.Replace('\'', '.');
        }

        public static string DotsToApostrophes(string text)
        {
            return text.Replace('.', '\'');
        }
    }
}
