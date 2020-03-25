using System;
using System.Diagnostics;
using System.IO;

namespace SimpleLoggers
{
    public class TextFileLogger : ILogger
    {
        private readonly string _logFilePath;

        public TextFileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

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
            WriteEntry($"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()} {messageType}: {message}");
        }

        private async void WriteEntry(string message)
        {
            try
            {
                using (var stream = File.AppendText(_logFilePath))
                {
                    await stream.WriteLineAsync(message);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(LogHelper.FormatException(ex));
            }
        }
    }
}
