using System;
using System.Diagnostics;

namespace SimpleLoggers
{
    public class DebugWindowLogger : ILogger
    {
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

        private void FormatEntry(string messageType, string message)
        {
            Debug.WriteLine($"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()} {messageType}: {message}");
        }
    }
}
