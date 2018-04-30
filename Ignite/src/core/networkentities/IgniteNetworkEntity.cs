using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class IgniteNetworkEntity
    {
        private String httpVersion;
        private Dictionary<String, String> headers;

        public IgniteNetworkEntity(String version, Dictionary<String, String> headers)
        {
            this.httpVersion = version;
            this.headers = headers;
        }

        public IgniteNetworkEntity()
        {

        }

        public Dictionary<String, String> getHeaders()
        {
            return headers;
        }

        public void setHeaders(Dictionary<String, String> headers)
        {
            this.headers = headers;
        }

        public String getHttpVersion()
        {
            return httpVersion;
        }

        public void setHttpVersion(String httpVersion)
        {
            this.httpVersion = httpVersion;
        }

    }
}
