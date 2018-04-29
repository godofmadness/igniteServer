using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class IgniteRequest : IgniteNetworkEntity
    {

        private String method;
        private String route;



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
