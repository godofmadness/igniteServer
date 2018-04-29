using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class IgniteRequestFactory
    {

        public static IgniteRequest GetInstance()
        {
            return new IgniteRequest();
        }
    }
}
