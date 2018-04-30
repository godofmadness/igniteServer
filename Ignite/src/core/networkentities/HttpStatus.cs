using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.networkentities
{
    class HttpStatus
    {

        public static int BAD_REQUEST = 400;
        public static String BAD_REQUEST_MESSAGE = "Bad Request";

        public static int OK = 200;
        public static String OK_MESSAGE = "Success";

        public static int NOT_FOUND = 404;
        public static String NOT_FOUND_MESSAGE = "Not Found";

        public static int SERVER_ERROR = 500;
        public static String SERVER_ERROR_MESSAGE = "Server Error";

        public static int LENGTH_REQUIRED = 411;
        public static String LENGTH_REQUIRED_MESSAGE = "Length Required";

        public static int METHOD_NOT_ALLOWED = 405;
        public static String METHOD_NOT_ALLOWED_MESSAGE = "Method Not Allowed";

    
    }
}
