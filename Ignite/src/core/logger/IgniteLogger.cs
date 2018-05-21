using System;
using System.Collections.Generic;
using System.Text;

namespace Ignite.src.core.logger
{
    class IgniteLogger
    {

        private static String pattern = "[IgniteServer]:{0} ";

        private void log(String msg, ConsoleColor color, String logLevel, params object[] args)
        {
            Console.ForegroundColor = color;
            Console.Write(pattern, logLevel);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg, args);
        }

        public void debug(String msg, params object[] args)
        {
            log(msg, ConsoleColor.Magenta, "DEBUG", args);
        }

        public void info(String msg, params object[] args)
        {
            log(msg, ConsoleColor.Cyan, "INFO", args);
        }


        public void warn(String msg, params object[] args)
        {
            log(msg, ConsoleColor.Yellow, "WARN", args);
        }


        public void error(String msg, params object[] args)
        {
            log(msg, ConsoleColor.Red, "WARN", args);
        }

    }
}
