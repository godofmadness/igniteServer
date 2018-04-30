using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class IgniteRequest : IgniteNetworkEntity
    {

        private String method;
        private String route;
        private Dictionary<String, String> body;

        public IgniteRequest(String method, String route, Dictionary<String, String> body, String httpVersion, Dictionary<String, String> headers) : base(httpVersion, headers)
        {
            this.method = method;
            this.route = route;
            this.body = body;
        }

        public IgniteRequest()
        {

        }



        public Dictionary<String, String> getBody()
        {
            return body;
        }

        public void setBody(Dictionary<String, String> body)
        {
            this.body = body;
        }


        public String getMethod()
        {
            return method;
        }

        public void setMethod(String method)
        {
            this.method = method;
        }

        public String getRoute()
        {
            return route;
        }

        public void setRoute(String route)
        {
            this.route = route;
        }

    }
}
