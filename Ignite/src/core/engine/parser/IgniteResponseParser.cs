using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;

namespace Ignite.src.core.engine.parser
{
    class IgniteResponseParser
    {

        private HeadersParser headersParser;
        private BodyParser bodyParser;

        public IgniteResponseParser()
        {
            headersParser = new HeadersParser();
            bodyParser = new BodyParser();
        }

        public String stringify(IgniteResponse response)
        {
            StringBuilder rawResponse = new StringBuilder();

            // stringify method core line
            List<String> coreLine = new List<String>();
            coreLine.Add(response.getHttpVersion());
            coreLine.Add(response.getStatusCode().ToString());
            coreLine.Add(response.getStatusMessage());
            rawResponse.Append(String.Join(ParserConstants.CORE_META_VALUES_DELIMETER, coreLine));
            rawResponse.Append(ParserConstants.REQUEST_META_DELIMETER);

            // stringify headers
            rawResponse.Append(headersParser.stringify(response.getHeaders()));
            rawResponse.Append(ParserConstants.REQUEST_META_DELIMETER);

            // stringify body
            rawResponse.Append(response.getBody());
            //rawResponse.Append(ParserConstants.EOF);

            return rawResponse.ToString();
        }
    }
}
