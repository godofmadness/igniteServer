using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class HttpHeaders
    {

        public static String ContentType = "Content-Type";
        public static String ContentLength = "Content-length";
        public static String UserAgent = "User-Agent";
        public static String Host = "Host";
        public static String Connection = "Connection";
        public static String Date = "Date";
        public static String Server = "Server";
        public static String Status = "Status";


        public static String ContentTypeDefaultValue = "text/plain";
        public static String ContentLengthDefaultValue = "0";
        public static String ConnectionDefautlValue = "close";
        public static String ServerDefaultValue = "IgniteServer";

    }
}
