using System;

namespace SimpleLoggers
{
    public class ConsoleLogger : ILogger
    {
        #region ILogger Members

        public void Info(string message)
        {
            FormatEntry("Info", message);
        }

        public void Warning(string message)
        {
            FormatEntry("Warning", message);
        }

        public void Error(string message)
        {
            FormatEntry("Error", message);
        }

        #endregion

        private void FormatEntry(string messageType, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()} {messageType}: {message}");
        }
    }
}
