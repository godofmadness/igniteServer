using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;


namespace Ignite.src.core.engine.parser {

    class IgniteRequestParser {

        private HeadersParser headersParser;
        private BodyParser bodyParser;

        public IgniteRequestParser() {
            headersParser = new HeadersParser();
            bodyParser = new BodyParser();
        }

        


        public IgniteRequest Parse(String rawRequest) {

            String[] partials = rawRequest.Split(ParserConstants.REQUEST_META_DELIMETER);


            String[] coreMetaPart = partials[0].Split(" ");
            String rawHeaders = partials[1].Split(ParserConstants.REQUEST_HEADERS_DELIMETER)[0];
            String rawBody = partials[1].Split(ParserConstants.REQUEST_HEADERS_DELIMETER)[1];

            Console.WriteLine("IgniteRequestParser@Parse | raw core meta part {0}", coreMetaPart);
            Console.WriteLine("IgniteRequestParser@Parse | headers part {0}", rawHeaders);
            Console.WriteLine("IgniteRequestParser@Parse | body part {0}", rawBody);

            Dictionary<String, String> body = bodyParser.Parse(rawBody);
            Dictionary<String, String> headers = headersParser.Parse(rawHeaders);

            Console.WriteLine("IgniteRequestParser@Parse |  parsed body {0}", body);
            Console.WriteLine("IgniteRequestParser@Parse |  parsed headers {0}", headers);


            IgniteRequest request = IgniteRequestFactory.GetInstance();
            request.setMethod(coreMetaPart[0]);
            request.setRoute(coreMetaPart[1]);
            request.setHttpVersion(coreMetaPart[2]);
            request.setBody(body);
            request.setHeaders(headers);

            return request;
        }

    }
}
