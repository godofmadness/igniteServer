using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.engine.parser
{
    class HeadersParser : AbstractKVParser
    {


     
        public static String HEADERS_DELIMETER = "\r\n";
        public static String KV_DELIMETER = ":";

        public override Dictionary<string, string> GetContainer()
        {
            return new Dictionary<String, String>();
        }

        public override string GetKVDelimeter()
        {
            return KV_DELIMETER;
        }

        public override string GetMainDelimeter()
        {
            return HEADERS_DELIMETER;
        }
    }
}
