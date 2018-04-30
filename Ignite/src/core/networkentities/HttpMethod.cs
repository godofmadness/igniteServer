using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class HttpMethod {

        public static String GET = "GET";
        public static String POST = "POST";
        public static String PUT = "PUT";
        public static String DELETE = "DELETE";

        public static List<String> getAvalibleMethods() {
            List<String> list = new List<String>();
            list.Add(GET);
            list.Add(POST);
            list.Add(PUT);
            list.Add(DELETE);

            return list;
        }
    }
}
