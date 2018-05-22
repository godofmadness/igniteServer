using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.logger;
using Ignite.src.core.networkentities;


namespace Ignite.src.core.engine.validator
{
    class IgniteRequestValidatorService
    {

        private static IgniteLogger logger = new IgniteLogger();
        private static String validHttpVersion = "HTTP/1.1";

        // core request engine low level validation logic
        public static IgniteResponseStatus validate(IgniteRequest request) {

            // not valid version
            if (!request.getHttpVersion().Equals(validHttpVersion)) {
                Console.WriteLine("IgniteERquestValidatorService@validate | http version not valid, sending 400");
                return new IgniteResponseStatus(HttpStatus.BAD_REQUEST, HttpStatus.BAD_REQUEST_MESSAGE);
            }

            if (request.getRoute().Equals("")) {
                logger.warn("IgniteERquestValidatorService@validate | route not valid, sending 400");
                return new IgniteResponseStatus(HttpStatus.BAD_REQUEST, HttpStatus.BAD_REQUEST_MESSAGE);
            }

            if (!request.getMethod().Equals(HttpMethod.GET) && !request.getHeaders().ContainsKey(HttpHeaders.ContentLength)) {
                logger.warn("IgniteERquestValidatorService@validate | no content length header sending 411");
                return new IgniteResponseStatus(HttpStatus.LENGTH_REQUIRED, HttpStatus.LENGTH_REQUIRED_MESSAGE);
            }
             
            // not supported method
            if (HttpMethod.getAvalibleMethods().IndexOf(request.getMethod()) == -1) {
                logger.warn("IgniteERquestValidatorService@validate | not allowed method, sending 501");
                return new IgniteResponseStatus(HttpStatus.NOT_IMPLEMENTED, HttpStatus.NOT_IMPLEMENTED_MESSAGE);
            }

            Dictionary<String, String> headers = request.getHeaders();
            
            foreach (KeyValuePair<String, String> entry in headers) {

                if (entry.Key.Equals("") || entry.Value.Equals("")) {
                    logger.warn("IgniteERquestValidatorService@validate | headers not valid, sending 400");
                    return new IgniteResponseStatus(HttpStatus.BAD_REQUEST, HttpStatus.BAD_REQUEST_MESSAGE);
                }
            }


            return new IgniteResponseStatus(HttpStatus.OK, HttpStatus.OK_MESSAGE);
        }
    }
}
