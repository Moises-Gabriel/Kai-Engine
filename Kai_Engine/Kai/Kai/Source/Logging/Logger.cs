using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kai.Source.Logging
{
    public enum LogType
    {
        Info,
        Warning,
        Error
    }
    
    internal class Logger
    {
        public string Log(LogType type, string message)
        {
            var time = DateTime.Now.ToString("h:mm:ss tt");

            switch (type)
            {
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine($"{time} {type}: " + message);
            return message;
        }
    }
}
