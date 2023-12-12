using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEngine.Utility
{
    public static class Log
    {

        private static ConsoleColor _defaultColor = ConsoleColor.White;
        private static ConsoleColor _warningColor = ConsoleColor.DarkYellow;
        private static ConsoleColor _errorColor = ConsoleColor.Red;
        private static ConsoleColor _debugColor = ConsoleColor.Cyan;

        public static void Write(string text)
        {

            Console.WriteLine($"[{DateTime.Now} (Total Runtime: {FrameMetrics.TotalRuntime}s)] {text}");

        }

        public static void WriteWarning(string text)
        {

            Console.ForegroundColor = _warningColor;
            Write(text);
            Console.ForegroundColor = _defaultColor;

        }

        public static void WriteError(string text)
        {

            Console.ForegroundColor = _errorColor;
            Write(text);
            Console.ForegroundColor = _defaultColor;

        }

        public static void WriteDebug(string text)
        {

            Console.ForegroundColor = _debugColor;
            Write(text);
            Console.ForegroundColor = _defaultColor;

        }

    }
}
