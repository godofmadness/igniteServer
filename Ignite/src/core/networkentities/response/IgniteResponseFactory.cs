using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.engine.parser;

namespace Ignite.src.core.networkentities
{
    class IgniteResponseFactory
    {

        public static Dictionary<String, String> initDefaultHeaders() {
            Dictionary<String, String> defaultHeaders = new Dictionary<String, String>();
            defaultHeaders.Add(HttpHeaders.Date,  " " + DateTime.Now.ToString());
            defaultHeaders.Add(HttpHeaders.Connection, " " + HttpHeaders.ConnectionDefautlValue);
            defaultHeaders.Add(HttpHeaders.Server, " " + HttpHeaders.ServerDefaultValue);
            defaultHeaders.Add(HttpHeaders.ContentType, " " + HttpHeaders.ContentTypeDefaultValue);
            defaultHeaders.Add(HttpHeaders.ContentLength, " " + HttpHeaders.ContentLengthDefaultValue);

            return defaultHeaders;

        }

        public static String initDefaultBody() {
            return "";
        }

        public static IgniteResponse getInstance(IgniteResponseStatus status) {
            Dictionary<String, String> headers = initDefaultHeaders();
            String body = initDefaultBody();

            return new IgniteResponse(status.getCode(), status.getMessage(), body, "HTTP/1.1", headers);
        }

        public static IgniteResponse getInstance()
        {
            Dictionary<String, String> headers = initDefaultHeaders();
            String body = initDefaultBody();

            return new IgniteResponse(HttpStatus.OK, HttpStatus.OK_MESSAGE, body, "HTTP/1.1", headers);
        }
    }
}
