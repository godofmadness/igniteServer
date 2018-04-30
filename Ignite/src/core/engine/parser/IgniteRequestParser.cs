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
            Console.Write("IgniteRequestParser@Parse | Starting parsing of request {0}", rawRequest);

            String[] partials = rawRequest.Split(ParserConstants.REQUEST_META_DELIMETER);


            String[] coreMetaPart = partials[0].Split(" ");
            String rawHeaders = partials[1].Split(ParserConstants.REQUEST_HEADERS_DELIMETER)[0];

            Console.WriteLine("IgniteRequestParser@Parse | raw core meta part {0}, {1}, {2}", coreMetaPart[0], coreMetaPart[1], coreMetaPart[2]);
            rawHeaders = rawHeaders.Substring(1, rawHeaders.Length - 1);
            Console.WriteLine("IgniteRequestParser@Parse | headers part {0}", rawHeaders);


            Dictionary<String, String> headers = headersParser.Parse(rawHeaders);
            Console.WriteLine("IgniteRequestParser@Parse |  parsed headers {0}", headers);

            IgniteRequest request = IgniteRequestFactory.GetInstance();
            request.setMethod(coreMetaPart[0]);
            request.setRoute(coreMetaPart[1]);
            request.setHttpVersion(coreMetaPart[2]); 
            request.setHeaders(headers);


            // if get request skip body parsing
            if (!coreMetaPart[0].Equals(NetworkMethod.GET)) {
                String rawBody = partials[1].Split(ParserConstants.REQUEST_HEADERS_DELIMETER)[1];
                // no body
                rawBody = rawBody.Split(ParserConstants.EOF)[0];
                
                Console.WriteLine("IgniteRequestParser@Parse | body part {0}", rawBody);
                Dictionary<String, String> body = bodyParser.Parse(rawBody);
                Console.WriteLine("IgniteRequestParser@Parse |  parsed body {0}", body);
                request.setBody(body);
            }

            Console.Write("IgniteRequestParser@Parse | created request {0}", request);
            return request;
        }

    }
}
