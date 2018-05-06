using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.config
{
    class IgniteConfiguration
    {


        private Dictionary<String, String> kvs = new Dictionary<String, String>();

        public String getProperty(String key)
        {
            return kvs[key];
        }


        public void setProperty(String key, String value) {
            kvs[key] = value;
        }

       

    }
}
