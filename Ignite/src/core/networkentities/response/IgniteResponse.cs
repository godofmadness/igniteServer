using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class IgniteResponse : IgniteNetworkEntity
    {
        private int statusCode;
        private String statusMessage;
        private String body;


        public IgniteResponse(int statusCode, String statusMessage, String body, String httpVersion, Dictionary<String, String> headers) : base(httpVersion, headers)
        {
            this.statusCode = statusCode;
            this.statusMessage = statusMessage;
            this.body = body;
        }

        public String getBody()
        {
            return body;
        }

        public void setBody(String body)
        {
            this.body = body;
        }


        public int getStatusCode()
        {
            return statusCode;
        }

        public void setStatusCode(int statusCode)
        {
            this.statusCode = statusCode;
        }

        public String getStatusMessage()
        {
            return statusMessage;
        }

        public void setStatusMessage(String statusMessage)
        {
            this.statusMessage = statusMessage;
        }
    }
}
