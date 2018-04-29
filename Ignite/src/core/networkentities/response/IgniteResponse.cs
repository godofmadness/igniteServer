using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class IgniteResponse : IgniteNetworkEntity
    {
        private int statusCode;
        private String statusMessage;

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
