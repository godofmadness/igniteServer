using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.engine.parser
{
    class HeadersParser : AbstractKVParser
    {


        private Dictionary<String, String> headers = new Dictionary<String, String>();
        private String HEADERS_DELIMETER = "\n";
        private String KV_DELIMETER = ":";

        public override Dictionary<string, string> GetContainer()
        {
            return headers;
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
