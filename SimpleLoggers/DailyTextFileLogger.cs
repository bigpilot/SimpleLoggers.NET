using System;
using System.Diagnostics;
using System.IO;

namespace SimpleLoggers
{
    public class DailyTextFileLogger : ILogger
    {
        private readonly string _logFilePath;

        public DailyTextFileLogger(string logFileDirectory, string logFileName)
        {
            _logFilePath = $"{Path.Combine(logFileDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "--" + logFileName)}";
        }

        #region ILogger Members

        public void Info(string message)
        {
            FormatAndWriteEntry("Info", message);
        }

        public void Warning(string message)
        {
            FormatAndWriteEntry("Warning", message);
        }

        public void Error(string message)
        {
            FormatAndWriteEntry("Error", message);
        }

        #endregion

        private void FormatAndWriteEntry(string messageType, string message)
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
