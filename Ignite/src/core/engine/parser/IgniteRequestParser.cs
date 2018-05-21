using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.logger;
using Ignite.src.core.networkentities;


namespace Ignite.src.core.engine.parser {

    class IgniteRequestParser {

        private HeadersParser headersParser;
        private BodyParser bodyParser;
        private IgniteLogger logger = new IgniteLogger();

        public IgniteRequestParser() {
            headersParser = new HeadersParser();
            bodyParser = new BodyParser();
        }

        


        public IgniteRequest Parse(String rawRequest) {
            //Console.Write("IgniteRequestParser@Parse | Starting parsing of request {0}", rawRequest);


            String[] hBPartials = rawRequest.Split(ParserConstants.REQUEST_HEADERS_DELIMETER);
   
            String[] partials = hBPartials[0].Split(ParserConstants.REQUEST_META_DELIMETER);

            //Console.WriteLine("IgniteRequestParser@Parse | {0}, {1}", hBPartials[0]);
           // Console.WriteLine("LENGTH {0}", partials[4]);

            String[] coreMetaPart = partials[0].Split(" ");

            StringBuilder rawHeaders = new StringBuilder();
            for (int i= 1; i < partials.Length; i++)
            {
                rawHeaders.Append(partials[i]);

                if (partials.Length - 1 != i) {
                    rawHeaders.Append(HeadersParser.HEADERS_DELIMETER);
                }
            }

            logger.debug("IgniteRequestParser@Parse | raw core meta part {0}, {1}, {2}", coreMetaPart[0], coreMetaPart[1], coreMetaPart[2]);

            logger.debug("IgniteRequestParser@Parse | headers part \n{0}", rawHeaders.ToString());


            Dictionary<String, String> headers = headersParser.Parse(rawHeaders.ToString());
            //Console.WriteLine("IgniteRequestParser@Parse |  parsed headers {0}", headers);

            IgniteRequest request = IgniteRequestFactory.GetInstance();
            request.setMethod(coreMetaPart[0]);
            request.setRoute(coreMetaPart[1]);
            request.setHttpVersion(coreMetaPart[2]); 
            request.setHeaders(headers);


            // if get request skip body parsing
            if (!coreMetaPart[0].Equals(HttpMethod.GET)) {
                String rawBody = hBPartials[1];


                logger.debug("IgniteRequestParser@Parse | body part {0}", rawBody);
                Dictionary<String, String> body = bodyParser.Parse(rawBody);
                //Console.WriteLine("IgniteRequestParser@Parse |  parsed body {0}", body);
                request.setBody(body);
            }

            //Console.Write("IgniteRequestParser@Parse | created request {0}", request);
            return request;
        }

    }
}
