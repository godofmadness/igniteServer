using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;

namespace Ignite.src.core.engine.parser
{
    class BodyParser : AbstractKVParser {


        private Dictionary<String, String> body = new Dictionary<String, String>();
        private String BODY_PARAMS_DELIMETER = "&";
        private String KV_DELIMETER = "=";

        public override Dictionary<string, string> GetContainer()
        {
            return body;
        }

        public override string GetKVDelimeter()
        {
            return KV_DELIMETER;
        }

        public override string GetMainDelimeter()
        {
            return BODY_PARAMS_DELIMETER;
        }

     
    }
}
